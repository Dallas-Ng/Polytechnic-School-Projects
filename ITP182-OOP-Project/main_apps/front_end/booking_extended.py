"""
Written by:
Dallas 180522Y
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session, Markup, json
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

booking_ext = Blueprint('booking_ext', __name__)


# Front stuff

# Admin
@booking_ext.route('/admin_booking_statistics/')
def booking_statistics():
    db_bookings = access_database('bookings', 'bookings')
    month_list = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    month_fare = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    for key in db_bookings.keys():
        obj = db_bookings[key]
        if obj.get_date()[-4:] == '2019':
            month_date = padding(int(obj.get_date()[3:5]))
            month_list[int(month_date)-1] += 1

    for key in db_bookings.keys():
        obj = db_bookings[key]
        if obj.get_date()[-4:] == '2019':
            month_date = padding(int(obj.get_date()[3:5]))
            month_fare[int(month_date)-1] += obj.get_fare()

    return render_template('booking/admin/admin_booking_statistics.html',
                           month_list=json.dumps(month_list), month_fare=json.dumps(month_fare))


@booking_ext.route('/booking_action/<action>/<string:booking_id>/')
def booking_action(action, booking_id):
    db_bookings = access_database('bookings', 'bookings')

    # Delete Function
    if action == 'delete':
        obj = db_bookings[booking_id]

        if greater(change_time(obj.get_time()), current_time()) and greater(obj.get_date(), current_date()):
            access_customer(session['current_user'], 'wallet', obj.get_fare())

        db_deleted_bookings = access_database('bookings', 'del_bookings')

        obj.deleted_by(session['current_user'])
        db_deleted_bookings[booking_id] = obj

        del db_bookings[booking_id]
        db_bookings.close()
        db_deleted_bookings.close()

    # Undo Function
    elif action == 'undo':
        db_deleted_bookings = access_database('bookings', 'del_bookings')
        db_bookings = access_database('bookings', 'bookings')

        data = db_deleted_bookings[booking_id]
        db_bookings[data.get_booking_id()] = data

        del db_deleted_bookings[booking_id]

        db_deleted_bookings.close()
        db_bookings.close()

    # View Barcode Function
    elif action == 'view':
        if session['current_user'] == 'admin':
            back = 'admin_booking/none/none/none/none/'
        else:
            back = 'booking_home'
        obj = db_bookings[booking_id]
        date = obj.get_date()
        time = obj.get_time()
        school = obj.get_school()
        fare = obj.get_fare()
        location = obj.get_location()
        completed = obj.get_completed_status()
        return render_template('booking/booking_barcode.html', barcode=booking_id, back=back, date=date,
                               time=time, school=school, fare=fare, location=location, completed=completed)

    # Redirection
    if session['current_user'].upper() == 'ADMIN':
        if action == 'delete' or action == 'complete':
            return redirect(url_for('dev_booking.admin_booking', action=action,
                                    username_selected='none', selected='none', order='none', time='none'))
        if action == 'update':
            return redirect(url_for('dev_booking.admin_booking_information'))
        else:
            return redirect('/admin_booking_deleted/none/none/none/none/')
    else:
        return redirect(url_for('booking.booking_home'))
