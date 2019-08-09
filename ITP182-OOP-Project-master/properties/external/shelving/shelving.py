"""
Written by:
Dallas 180522Y
Randy 181773X
"""
from properties.external.library_python.functions import *
from properties.external.library_python.form import *

from properties.external.shelving.object_account import *
from properties.external.shelving.object_admin import *
from properties.external.shelving.object_booking import *
from properties.external.shelving.object_customer import *
from properties.external.shelving.object_feedback import *
from properties.external.shelving.object_lostandfound import *

from datetime import datetime, timedelta
import shelve as s


# ======================================================================================#
#                                      DATABASE                                         #
# ======================================================================================#
def retrieve_database(directory, database_name):
    db = s.open('properties/database/%s/%s.db' % (directory, database_name))
    database_list = []
    for key in db.keys():
        obj = db[key]
        database_list.append(obj)
    db.close()
    return database_list


def access_database(directory, database_name):
    database = s.open('properties/database/%s/%s.db' % (directory, database_name))
    return database


# ======================================================================================#
#                          RETRIEVE DATABASE USING USERNAME                             #
#                  USERNAME RETURNS DATA / USERNAME_LIST RETURNS LIST                   #
# ======================================================================================#
def retrieve_database_username(directory, database_name, username):
    db = s.open('properties/database/%s/%s.db' % (directory, database_name))
    data = db[username]
    db.close()
    return data


def retrieve_database_username_list(directory, database_name, username):
    db = s.open('properties/database/%s/%s.db' % (directory, database_name))
    database_list = []
    for key in db.keys():
        if username.upper() == 'ADMIN':
            obj = db[key]
            database_list.append(obj)
        elif db[key].get_username() == username:
            obj = db[key]
            database_list.append(obj)
    db.close()
    return database_list


# ======================================================================================#
#                             RETRIEVE DATABASE FOR ADMIN                               #
#                  FIRST FILTER: MONTH OR YEAR || SECOND FILTER: DATE                   #
# ======================================================================================#
def retrieve_database_feedback_filter(year, month):
    db = s.open('properties/database/feedback/feedback.db')
    database_list = []
    for key in db.keys():
        obj = db[key]
        if year == 'none' and month == 'none':
            database_list.append(obj)

        elif year != 'none' and month != 'none':
            print('herere4444222')
            print(year, month, obj.get_year(), obj.get_month())
            if obj.get_year() == year and obj.get_month() == month:
                database_list.append(obj)

        elif year and month == 'none':
            print('herere222333')
            if obj.get_year() == year:
                database_list.append(obj)
        elif year == 'none' and month:
            print('herere222')
            if obj.get_month() == month:
                database_list.append(obj)
    db.close()
    return database_list


# ======================================================================================#
#                           RETRIEVE DATABASE FOR CUSTOMER                              #
#                                ITEM: WALLET OR POINT                                  #
# ======================================================================================#
def retrieve_customer(customer, item):
    db = access_database('currency', 'currency')
    obj = db[customer]
    if item.lower() == 'wallet':
        data = obj.get_wallet()
        return str(data)
    elif item.lower() == 'points':
        data = obj.get_points()
        return str(data)


# ======================================================================================#
#                                   ACCESSING DATABASE                                  #
#                             CHANGING OBJ'S WALLET OR POINT                            #
# ======================================================================================#
def access_customer(customer, item, amount):
    db = access_database('currency', 'currency')
    obj = db[customer]
    if item.lower() == 'wallet':
        obj.wallet_deposit(amount)
        db[customer] = obj
    elif item.lower() == 'points':
        obj.points_add(amount)
        db[customer] = obj
    elif item.lower() == 'delete_points':
        obj.points_deduct(amount)
        db[customer] = obj


def booking_balance_change(customer, amount):
    db = access_database('currency', 'currency')
    for key in db.keys():
        obj = db[key]
        if obj.get_username() == customer:
            obj.wallet_withdraw(amount)
            db[key] = obj


# ======================================================================================#
#                                       BOOKING                                         #
#                                                                                       #
# ======================================================================================#
greater = lambda foo, bar: True if (foo >= bar) else False


def retrieve_user_bookings(directory, username, time):
    db_bookings = access_database('bookings', '%s' % directory)
    booking_list = []
    for key in db_bookings.keys():
        data = db_bookings[key]
        if username == 'none' or data.get_username() == username:
            if time == 'none':
                booking_list.append(data)
            elif time == 'completed':
                if data.get_completed_status() == 'Completed' and data.get_completed_status():
                    booking_list.append(data)
            elif time == 'not completed':
                if data.get_completed_status() == 'Not completed' or not data.get_completed_status():
                    booking_list.append(data)
            elif time == 'today completed':
                if convert(data.get_date()) == convert(current_date()):
                    if greater(change_time(data.get_time()), current_time()):
                        booking_list.append(data)
            elif time == 'today uncompleted':
                if convert(data.get_date()) == convert(current_date()):
                    if not greater(change_time(data.get_time()), current_time()):
                        booking_list.append(data)
            elif time == 'today':
                if convert(data.get_date()) == convert(current_date()):
                    booking_list.append(data)
            elif time == 'past':
                if not convert(data.get_date()) >= convert(current_date()):
                    if not greater(change_time(data.get_time()), current_time()):
                        booking_list.append(data)
            elif time == 'future' or time == 'all':
                if convert(data.get_date()) > convert(current_date()):
                    booking_list.append(data)
                else:
                    if convert(data.get_date()) == convert(current_date()):
                        if greater(change_time(data.get_time()), current_time()):
                            booking_list.append(data)
    db_bookings.close()
    booking_list.sort(key=lambda x: (x.get_date()[3:5], x.get_date()[0:2], x.get_time()))
    return booking_list


def check_updates():
    database = s.open('properties/database/bookings/updates.db')
    key_list = ['home_updates', 'bookings_updates']
    if key_list[0] not in database.keys() and key_list[1] not in database.keys():
        database['home_updates'] = ''
        database['booking_updates'] = ''

