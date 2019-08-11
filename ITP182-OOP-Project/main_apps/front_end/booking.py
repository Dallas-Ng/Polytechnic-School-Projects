"""
Written by:
Dallas 180522Y
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session, Markup
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

booking = Blueprint('booking', __name__)


@booking.route('/booking_home/', methods=['GET', 'POST'])
@booking.route('/booking_home/<time_frame>', methods=['GET', 'POST'])
def booking_home(time_frame='all'):
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    form = BookingForm(request.form)

    # Opening Databases
    booking_list = retrieve_user_bookings('bookings', session['current_user'], time_frame)
    booked = retrieve_user_bookings('bookings', session['current_user'], 'all')
    db_customer_wallet = retrieve_customer(session['current_user'], 'wallet')
    db_user = access_database('accounts', 'accounts')

    # Retrieve updates from admin
    db_updates = access_database('bookings', 'updates')
    booking_updates = db_updates['booking_updates']

    # Check if customer has top up after registering
    if int(db_customer_wallet) == 0:
        flash(Markup('Hey! It looks like you have not topped up.'
                     ' <a href="/overview_wallet" class="alert-link"> Click here to view your wallet!</a>'), 'danger')

    if request.method == 'POST':
        db_bookings = access_database('bookings', 'bookings')

        # Using html form to get data; return false if null
        edit_location = request.form.get('edit_location', False)
        edit_date = request.form.get('edit_datepicker', False)
        edit_time = request.form.get('edit_timepicker', False)
        edit_booking_id = request.form.get('hiddenField', False)

        # If form validate, it means its a new booking and not an edit
        if form.validate():

            # Validation Area =================================================
            # Check if new customer has updated school on profile
            if db_user[session['current_user']].get_school() == 'No school':
                flash(Markup('Hey! It looks like you have not put in your school.'
                             ' <a href="/overview_customer_edit" class="alert-link"> '
                             'Click here to edit your profile!</a>'), 'danger')
                return redirect(url_for('booking.booking_home'))
            else:
                if not 2100 >= int(change_time(form.time.data)[:2] + change_time(form.time.data)[3:5]) >= 800:
                    print(change_time(form.time.data)[:2] + change_time(form.time.data)[3:5])
                    flash('Bookings are available between 8am and 9pm only. Please book a different time.', 'info')
                    return redirect(url_for('booking.booking_home'))
                else:
                    new_fare = fare(form.location.data)
                    if int(db_customer_wallet) < new_fare:
                        flash('Not enough money in your wallet. Please top up. Missing amount: $%3.2f' %
                              (new_fare - int(db_customer_wallet)), 'danger')
                        return redirect(url_for('booking.booking_home'))
                    else:
                        if form.date.data == current_date():
                            if change_time(form.time.data) < current_time():
                                flash('Please do not book before the current time', 'danger')
                                return redirect(url_for('booking.booking_home'))

            for bookings in booked:
                if bookings.get_date() == form.date.data:
                    if bookings.get_time() == form.time.data:
                        flash('Invalid booking. Please do not book the two bookings on the same time and date',
                              'danger')
                        return redirect(url_for('booking.booking_home'))
            # =================================================================

            # Deduct money based on location
            booking_balance_change(session['current_user'], new_fare)

            # Retrieve user's information and put it inside booking object
            user_data = db_user[session['current_user']]
            new_booking = Booking(session['current_user'], user_data.get_name(), form.location.data,
                                  user_data.get_school(), form.date.data, form.time.data, new_fare)
            db_bookings[new_booking.get_booking_id()] = new_booking
            db_user.close()
            db_bookings.close()

            flash('Booking Created. New Available Balance: $%s' % retrieve_customer(session['current_user'], 'wallet'),
                  'success')
            return redirect(url_for('booking.booking_home', time_frame=time_frame))

        elif edit_time or edit_location != 'None' or edit_date:
            booking_edit = db_bookings[edit_booking_id]

            if edit_location != 'None':
                # If location is changed, revert the original amount and subtract the new amount
                access_customer(session['current_user'], 'wallet', booking_edit.get_fare())
                booking_balance_change(session['current_user'], fare(edit_location))

                booking_edit.set_fare(fare(edit_location))
                booking_edit.set_location(edit_location)

            if edit_date:
                booking_edit.set_date(edit_date)

            if edit_time:
                # Check time
                if not 2100 >= int(change_time(edit_time)[:2] + change_time(edit_time)[3:5]) >= 800:
                    print(change_time(form.time.data)[:2] + change_time(form.time.data)[3:5])
                    flash('Bookings are available between 8am and 9pm only. Please change to an available time.', 'info')
                    return redirect(url_for('booking.booking_home'))
                booking_edit.set_time(edit_time)

            # Prevents editing for going over validations of checking each date and each time
            for bookings in booked:
                if edit_date and edit_time:
                    if bookings.get_date() == edit_date:
                        if bookings.get_time() == edit_time:
                            flash('Invalid booking. Please do not change the existing booking to the same timing and '
                                  'date as a already registered booking', 'danger')
                            return redirect(url_for('booking.booking_home'))
                elif edit_date:
                    if bookings.get_date() == edit_date:
                        if bookings.get_time() == db_bookings[edit_booking_id].get_time():
                            flash('Invalid booking. Please do not change the existing booking to the same timing and '
                                  'date as a already registered booking', 'danger')
                            return redirect(url_for('booking.booking_home'))

                elif edit_time:
                    if bookings.get_date() == db_bookings[edit_booking_id].get_date():
                        if bookings.get_time() == edit_time:
                            flash('Invalid booking. Please do not change the existing booking to the same timing and '
                                  'date as a already registered booking', 'danger')
                            return redirect(url_for('booking.booking_home'))

            db_bookings[edit_booking_id] = booking_edit
            flash('Booking edited', 'success')
            return redirect(url_for('booking.booking_home', time_frame=time_frame))
    return render_template('booking/booking_page.html', time_frame=time_frame, booking_updates=booking_updates,
                           bookings=booking_list, wallet=db_customer_wallet, form=form,
                           user=session['current_user'],)


@booking.route('/feedback')
@booking.route('/booking_past/')
def booking_past():
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    completed_bookings = retrieve_user_bookings('bookings', session['current_user'], 'past')
    if '/feedback' in str(request.url_rule):
            return render_template('booking/booking_page_past.html', list=completed_bookings, back='overview')
    return render_template('booking/booking_page_past.html', list=completed_bookings, back='booking_home')

