"""
Written by:
Dallas 180522Y
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

account = Blueprint('account', __name__)


"""
This file contains the separate functions for logging in, registering and signing out.
This functions are not used after 26/DEC as I implemented them into 1 big function in main.py
The only function being used in this file is Logout
"""


@account.route('/logout/')
def logout():
    if session['current_user'].upper() != 'ADMIN':
        db_user = access_database('accounts', 'accounts')
        obj = db_user[session['current_user']]
        obj.update_last_seen(obj.get_sign_in())
        db_user[session['current_user']] = obj
        db_user.close()

    # Remove session['current_user']
    session['current_user'] = ''
    flash('Logged out!', 'info')
    return redirect(url_for('index.home'))


@account.route('/overview_customer_edit/', methods=['GET', 'POST'])
def overview_customer_edit():
    form = Particulars(request.form)

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    points_amount = retrieve_customer(session['current_user'], 'points')

    db_user = access_database('accounts', 'accounts')
    obj = db_user[session['current_user']]
    recent_login = obj.get_last_seen()

    if request.method == 'GET':
        form.name.default = obj.get_name()
        form.email.default = obj.get_email()
        form.process()

    if request.method == 'POST':
        if form.validate():
            name = form.name.data
            email = form.email.data
            school = form.school.data
            password = form.password.data
            c_password = form.confirm_password.data

            if name and name != obj.get_name():
                obj.set_name(name[0].upper() + name[1:].lower())

            if email and email != obj.get_email():
                obj.set_email(email[0].upper() + email[1:].lower())

            if school and school != obj.get_school() and school != 'No changes':
                obj.set_school(school)

            if password and password == c_password and password != obj.get_password():
                obj.set_password(password)

            db_user[session['current_user']] = obj
            db_user.close()
            flash('Changes made', 'success')
        else:
            flash('Invalid Input. Please try again.', 'danger')
        return redirect(url_for('account.overview_customer_edit'))
    return render_template('overview/particulars.html',
                           # Left Side of the Page
                           user=session['current_user'][0].upper() + session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount, points_amount=points_amount,
                           user_data=db_user[session['current_user']],
                           # Right Side of the Page
                           form=form)


# ============================================================================#
#                                                                             #
#                      DO NOT TOUCH ANYTHING BELOW THIS                       #
#                   Url used: sign_in, register, sign_in_regi                 #
#                                                                             #
# ============================================================================#


@account.route('/sign_in_regi/', methods=['GET', 'POST'])
def accountsignintest():
    form = SignIn(request.form)
    if request.method == 'POST':
        db_user = access_database('accounts', 'accounts')
        db_wallet = access_database('currency', 'currency')

        # Sign in
        sign_name = request.form.get('sign_username', False)
        sign_password = request.form.get('sign_password', False)

        # Register
        reg_username = request.form.get('reg_username', False)
        reg_password = request.form.get('reg_password', False)
        reg_confirm_password = request.form.get('reg_confirm_password', False)
        reg_email = request.form.get('reg_email', False)
        reg_name = request.form.get('reg_name', False)

        session['current_user'] = sign_name
        # Check Log in ###  and not sign_password
        if sign_name:
            if sign_name.split()[0].upper() == 'ADMIN':
                return redirect(url_for('admin.admin_page'))
            elif sign_name in db_user.keys():
                # Check password here VALIDATION
                obj = db_user[session['current_user']]
                obj.update_sign_in(date())
                db_user[session['current_user']] = obj
                db_user.close()
                db_wallet.close()
                flash('Logged in', 'success')
                return redirect(url_for('customer.overview'))
        else:
            new_user = Account(date(), reg_username, reg_name, reg_email,
                               reg_confirm_password, school='NYP')
            db_user[reg_username] = new_user
            # Creating customer class for new user
            new_wallet = Customer(reg_username)
            db_wallet[reg_username] = new_wallet
            db_user.close()
            db_wallet.close()
            flash('Registered! You may now log in.', 'success')
            return redirect(url_for('index.home'))
    return render_template('account/test.html', form=form)


@account.route('/sign_in/', methods=['GET', 'POST'])
def sign_in():
    form = SignIn(request.form)
    if request.method == 'POST':
        db_user = access_database('accounts', 'accounts')
        current_user = form.username.data
        session['current_user'] = current_user
        print('SIGNED IN:', session['current_user'].upper())

        if current_user.split()[0].upper() == 'ADMIN':
            return redirect(url_for('admin.admin_page'))

        if current_user in db_user.keys():
            obj = db_user[session['current_user']]
            obj.update_sign_in(date())
            db_user[session['current_user']] = obj

            flash('Logged in', 'success')
            return redirect(url_for('customer.overview'))
        # If invalid username/password, an alert will pop out
        print('INVALID USERNAME/PASSWORD')
        flash('Invalid Username/Password.', 'danger')
    return render_template('account/sign_in.html', form=form)


@account.route('/register/', methods=['GET', 'POST'])
def register():
    form = RegistrationForm(request.form)
    if request.method == 'POST':
        # Accessing all databases on initial registration
        db_user = access_database('accounts', 'accounts')
        db_wallet = access_database('currency', 'currency')
        create_username = form.username.data  # add validation on html
        # Creating new user
        new_user = Account(date(), create_username, form.name.data, form.email.data,
                           form.password.data, form.school.data)
        db_user[create_username] = new_user
        # Creating customer class for new user
        new_wallet = Customer(create_username)
        db_wallet[create_username] = new_wallet
        # Close all database
        db_user.close()
        db_wallet.close()
        flash('Registered! You may now log in.', 'success')
        return redirect(url_for('index.home'))
    return render_template('account/register.html', form=form)
