"""
Written by:
Dallas 180522Y
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

dev_booking = Blueprint('dev_booking', __name__)


@dev_booking.route('/admin_booking_deleted/<username_selected>/<time>/<selected>/<order>/')
@dev_booking.route('/admin_booking/<username_selected>/<time>/<selected>/<order>/')
def admin_booking(username_selected='none', time='none', selected='none', order='none'):
    # ===========================================================================
    # Retrieving List ==============================================================
    if '/admin_booking_deleted' in str(request.url_rule):
        directory = 'del_bookings'
    else:
        directory = 'bookings'

    # User Button
    booking_list_users = access_database('bookings', '%s' % directory)
    user_list = []
    for key in booking_list_users.keys():
        if booking_list_users[key].get_username() not in user_list:
            data_user = booking_list_users[key].get_username()
            user_list.append(data_user)

    # Booking list
    booking_list = retrieve_user_bookings(directory, username_selected, time)

    filter_username = username_selected

    # ===========================================================================
    # Sorting Lists ==============================================================
    if selected == 'none':
        pass

    if selected == 'booking':
        if order == 'ascending':
            booking_list.sort(key=lambda x: x.get_booking_id())
        else:
            booking_list.sort(key=lambda x: x.get_booking_id(), reverse=True)

    # Selected Fare
    elif selected == 'fare':
        if order == 'ascending':
            booking_list.sort(key=lambda x: x.get_fare())
        else:
            booking_list.sort(key=lambda x: x.get_fare(), reverse=True)

    # Selected School
    elif selected == 'school':
        if order == 'ascending':
            booking_list.sort(key=lambda x: x.get_school())
        else:
            booking_list.sort(key=lambda x: x.get_school(), reverse=True)

    # Date
    elif selected == 'date':
        if order == 'ascending':
            booking_list.sort(key=lambda x: (x.get_date(), x.get_time()))
        else:
            booking_list.sort(key=lambda x: (x.get_date(), x.get_time()), reverse=True)

    # Returning HTML
    if '/admin_booking_deleted' in str(request.url_rule):
        return render_template('booking/admin/admin_booking_deleted_page.html', booking_list=booking_list,
                               # Cards
                               current_booking_number=len(retrieve_user_bookings(directory, 'none', 'future')),
                               user_number=len(user_list),
                               # User Listing
                               username=username_selected, user_list=user_list,
                               # Filtering
                               time_frame=time, selector=selected, order=order, filter_username=filter_username)

    return render_template('booking/admin/admin_booking_page.html', booking_list=booking_list,
                           # Cards
                           current_booking_number=len(retrieve_user_bookings(directory, 'none', 'future')),
                           user_number=len(user_list),
                           # User Listing
                           username=username_selected, user_list=user_list,
                           # Filtering
                           time_frame=time, selector=selected, order=order, filter_username=filter_username)


@dev_booking.route('/admin_booking_information/', methods=['GET', 'POST'])
def admin_booking_information():
    db_bookings = access_database('bookings', 'updates')
    home_updates = db_bookings['home_updates']
    booking_updates = db_bookings['booking_updates']

    if request.method == 'POST':
        homepage_update = request.form.get('homepage_update', False)
        dashboard_update = request.form.get('dashboard_update', False)

        if homepage_update:
            if homepage_update == '/n':
                homepage_update = 'No updates'
            db_bookings['home_updates'] = homepage_update
            print(homepage_update)

        if dashboard_update:
            if dashboard_update == '/n':
                dashboard_update = 'No updates'
            db_bookings['booking_updates'] = dashboard_update

        return redirect(url_for('dev_booking.admin_booking_information'))
    return render_template('booking/admin/admin_booking_information.html',
                           home_updates=home_updates, booking_updates=booking_updates,
                           user=session['current_user'][0].upper() + session['current_user'][1:].lower(),
                           booking_number='!Number!')


@dev_booking.route('/complete/<booking_id>/<username_selected>/<time>/<selected>/<order>/')
def complete(booking_id, username_selected='none', time='none', selected='none', order='none'):
    db_bookings = access_database('bookings', 'bookings')
    obj = db_bookings[booking_id]
    obj.completed()
    db_bookings[booking_id] = obj
    return redirect(url_for('dev_booking.admin_booking',  time=time, selected=selected, order=order,
                            username_selected=username_selected))
