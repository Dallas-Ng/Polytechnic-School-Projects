"""
Written by:
Dallas 180522Y
Randy 181773X
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

customer = Blueprint('customer', __name__)


@customer.route('/overview/')
def overview():
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    points_amount = retrieve_customer(session['current_user'], 'points')
    user_data = access_database('accounts', 'accounts')
    db_updates = access_database('bookings', 'updates')

    home_updates = db_updates['home_updates']

    booking_list = retrieve_user_bookings('bookings', session['current_user'], 'today')

    obj = user_data[session['current_user']]
    recent_login = obj.get_last_seen()

    return render_template('overview/dashboard.html',
                           # For the left side of the page !!DONT TOUCH!!
                           user=session['current_user'][0].upper()+session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount, points_amount=points_amount,
                           user_data=user_data[session['current_user']],
                           # For the right side of the page !!DONT TOUCH!!
                           booking_list=booking_list, home_updates=home_updates,
                           booking_number=len(booking_list),)


@customer.route('/overview_points/')
def overview_points():
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    user_data = access_database('accounts', 'accounts')

    obj = user_data[session['current_user']]
    recent_login = obj.get_last_seen()

    points_amount = retrieve_customer(session['current_user'], 'points')
    return render_template('overview/points.html', points_amount=points_amount,
                           # For the left side of the page !!DONT TOUCH!!
                           user=session['current_user'][0].upper() + session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount,
                           user_data=user_data[session['current_user']])


@customer.route('/overview_points_reward/<button_number>')
def rewards(button_number):
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    points_amount = retrieve_customer(session['current_user'], 'points')

    user_data = access_database('accounts', 'accounts')

    obj = user_data[session['current_user']]
    recent_login = obj.get_last_seen()

    if button_number == 'button_1':
        if int(points_amount) >= 500:
            access_customer(session['current_user'], 'delete_points', 500)
            user_data = retrieve_customer(session['current_user'], 'points')
            flash('Success! Your remaining balance is: ' + str(user_data), 'success')
        else:
            flash('You have insufficient points', 'danger')
    elif button_number == 'button_2':
        if int(points_amount) >= 1000:
            access_customer(session['current_user'], 'delete_points', 1000)
            user_data = retrieve_customer(session['current_user'], 'points')
            flash('Success! Your remaining balance is: ' + str(user_data), 'success')
        else:
            flash('You have insufficient points', 'danger')

    elif button_number == 'button_3':
        if int(points_amount) >= 5000:
            access_customer(session['current_user'], 'delete_points', 5000)
            user_data = retrieve_customer(session['current_user'], 'points')
            flash('Success! Your remaining balance is: ' + str(user_data), 'success')
        else:
            flash('You have insufficient points', 'danger')

    points_amount = retrieve_customer(session['current_user'], 'points')

    return render_template('overview/points.html', points_amount=points_amount,
                           # For the left side of the page !!DONT TOUCH!!
                           user=session['current_user'][0].upper() + session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount,
                           user_data=obj)


@customer.route('/overview_status/')
def overview_status():
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    points_amount = retrieve_customer(session['current_user'], 'points')
    user_data = access_database('accounts', 'accounts')

    obj = user_data[session['current_user']]
    recent_login = obj.get_last_seen()

    status_list = status_generate()
    return render_template('overview/status.html', list=status_list,
                           # For the left side of the page !!DONT TOUCH!!
                           user=session['current_user'][0].upper()+session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount, points_amount=points_amount,
                           user_data=user_data[session['current_user']])
