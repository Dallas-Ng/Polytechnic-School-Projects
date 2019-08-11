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

dev_feedback = Blueprint('dev_feedback', __name__)


@dev_feedback.route('/admin_feedback/<year>/<month>/', methods=['GET', 'POST'])
def admin_feedback(year='none', month='none'):
    form = AdminFeedback(request.form)
    db_feedback = retrieve_database_feedback_filter(year, month)
    return render_template('admin/admin_dashboard_feedback.html', list=db_feedback, form=form,
                           user=session['current_user'], year=year, month=month)


@dev_feedback.route('/admin_feedback_delete/<feedback_id>/')
def admin_feedback_delete(feedback_id):
    db_feedback = access_database('feedback', 'feedback')
    del db_feedback[feedback_id]
    db_feedback.close()
    return redirect(url_for('dev_feedback.admin_feedback', month='none', year='none'))


