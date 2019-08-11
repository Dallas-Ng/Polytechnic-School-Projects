"""
Written by:
Dallas 180522Y
Tjandra 181110B
Faris 182915N
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

support = Blueprint('support', __name__)


@support.route('/feedback/<booking_id>', methods=['GET', 'POST'])
def feedback(booking_id):
    form = FeedbackForm(request.form)
    if request.method == 'POST':
        if form.validate():
            cleanliness = form.cleanliness.data
            punctuality = form.punctuality.data
            faulty = form.faulty.data
            vandalism = form.vandalism.data
            map = form.map.data
            payment = form.payment.data
            account = form.account.data
            aesthetic = form.aesthetic.data

            new_feedback = Feedback(session['current_user'], booking_id, cleanliness, punctuality, faulty, vandalism, map, payment, account, aesthetic)
            db_feedback = access_database('feedback', 'feedback')
            db_feedback[new_feedback.get_feedback_id()] = new_feedback
            db_feedback.close()
            return redirect(url_for('customer.overview'))
    return render_template('feedback/feedback_form.html', form=form)


@support.route('/lost_and_found/', methods=['GET', 'POST'])
def lost_and_found():
    form = LostAndFoundForm(request.form)
    db_lost_and_found = access_database('feedback', 'lostandfound')
    lost_and_found_list = retrieve_database('feedback', 'lostandfound')
    if session['current_user'].split()[0].upper() == 'ADMIN':
        return render_template('feedback/lost_and_found_retrieve.html', list=lost_and_found_list)
    if request.method == 'POST':
        status = form.status.data
        date = form.date.data
        time = form.time.data
        item = form.item.data
        description = form.description.data

        new_entry = LostAndFound(session['current_user'], description, item, date, status, time)
        db_lost_and_found[new_entry.get_lost_and_found_id()] = new_entry
        db_lost_and_found.close()
        return redirect(url_for('customer.overview'))

    return render_template('feedback/lost_and_found_form.html', form=form, list=lost_and_found_list)


@support.route('/lost_and_found_delete/<lost_and_found_id>')
def lost_and_found_delete(lost_and_found_id):
    db_lost_and_found = access_database('feedback', 'lostandfound')
    del db_lost_and_found[lost_and_found_id]
    db_lost_and_found.close()
    return redirect(url_for('support.lost_and_found'))


@support.route('/lost_and_found_status/<lost_and_found_id>', methods=['POST'])
def lost_and_found_status(lost_and_found_id):
    if request.method == 'POST':
        db_lost_and_found = access_database('feedback', 'lostandfound')
        obj = db_lost_and_found[lost_and_found_id]
        obj.set_status(request.form[lost_and_found_id])
        db_lost_and_found[lost_and_found_id] = obj
        return redirect(url_for('support.lost_and_found'))
