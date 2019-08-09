"""
Written by:
Dallas 180522Y
Tjandra 181110B
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

admin = Blueprint('admin', __name__)


@admin.route('/admin_page/')
def admin_page():
    return redirect(url_for('admin.admin_registered'))


@admin.route('/admin_registered/', methods=['GET', 'POST'])
def admin_registered():
    db_users = retrieve_database('accounts', 'accounts')
    if request.method == 'POST':
        customer_username = request.form.get('hiddenField', False)
        customer_email = request.form.get('user_email', False)
        customer_school = request.form.get('user_school', False)
        customer_name = request.form.get('user_name', False)

        print(customer_username, customer_school, customer_email, customer_name)

        db_user = access_database('accounts', 'accounts')
        obj = db_user[customer_username]
        if customer_email and not customer_email == obj.get_email():
            obj.set_email(customer_email)
        if customer_school != 'None' and not customer_school == obj.get_school():
            obj.set_school(customer_school)
        if customer_name and not customer_name == obj.get_name():
            obj.set_name(customer_name)
        db_user[customer_username] = obj

        return redirect(url_for('admin.admin_registered'))
    return render_template('admin/admin_registered.html', list=db_users)



