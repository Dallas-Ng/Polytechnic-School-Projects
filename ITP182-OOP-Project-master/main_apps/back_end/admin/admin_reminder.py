"""
Written by:
Dallas 180522Y
Tjandra 181110B
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *


dev_registered = Blueprint('dev_registered', __name__)


@dev_registered.route('/admin_reminder/', methods=['GET', 'POST'])
def admin_reminder():
    form = AdminReminder(request.form)
    reminder_list = retrieve_database('admin', 'reminders')
    if request.method == 'POST':
        db_reminders = access_database('admin', 'reminders')
        name = form.name.data
        information = form.info.data
        new_reminder = Reminder(session['current_user'], name, information)
        db_reminders[new_reminder.get_reminder_id()] = new_reminder
        return redirect(url_for('dev_registered.admin_reminder'))
    return render_template('admin/admin_reminder.html', form=form, list=reminder_list, user='user')


@dev_registered.route('/admin_reminder_delete/<reminder_id>/')
def admin_reminder_delete(reminder_id):
    db_reminders = access_database('admin', 'reminders')
    for key in db_reminders.keys():
        if db_reminders[key].get_reminder_id() == reminder_id:
            del db_reminders[key]
            return redirect(url_for('dev_registered.admin_reminder'))


@dev_registered.route('/admin_reminder_save/<reminder_id>', methods=['POST'])
def admin_reminder_save(reminder_id):
    if request.method == 'POST':
        db_reminders = access_database('admin', 'reminders')
        obj = db_reminders[reminder_id]
        obj.set_information(request.form[reminder_id])
        db_reminders[reminder_id] = obj
        return redirect(url_for('dev_registered.admin_reminder'))


@dev_registered.route('/important_action/<action>/<string:reminder_id>/')
def important_action(action, reminder_id):
    db_reminders = access_database('admin', 'reminders')
    obj = db_reminders[reminder_id]
    # Important Function
    if action == 'important':
        obj.important()
        db_reminders[reminder_id] = obj
        return redirect("http://127.0.0.1:5000/admin_reminder/")
    else:
        obj.notimportant()
        db_reminders[reminder_id] = obj
        return redirect("http://127.0.0.1:5000/admin_reminder/")
