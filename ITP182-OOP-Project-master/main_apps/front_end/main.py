"""
Written by:
Dallas 180522Y
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

index = Blueprint('index', __name__)


@index.route('/', methods=['GET', 'POST'])
@index.route('/about/', methods=['GET', 'POST'])
@index.route('/home/', methods=['GET', 'POST'])
def home():
    check_updates()
    if request.method == 'POST':
        # Opening Databases for checking or creation
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

        # If Sign in name is filled
        if sign_name:
            sign_name = sign_name.lower()
            # If name == admin go to admin page
            if sign_name.split()[0].upper() == 'ADMIN':
                if sign_password == 'admin':
                    session['current_user'] = sign_name
                    return redirect(url_for('admin.admin_page'))
                else:
                    flash('Invalid username or password. Please try again.', 'danger')
                    return redirect(url_for('index.home'))

            elif sign_name.lower() in db_user.keys():
                # If password is valid, move on
                if db_user[sign_name].get_password() == sign_password:
                    session['current_user'] = sign_name

                    obj = db_user[session['current_user']]
                    obj.update_sign_in(date())
                    db_user[session['current_user']] = obj
                    db_user.close()
                    db_wallet.close()
                    flash('Logged in', 'success')
                    return redirect(url_for('customer.overview'))
                else:
                    # Flash and return
                    flash('Invalid username or password. Please try again.', 'danger')
                    return redirect(url_for('index.home'))
            flash('Invalid username or password. Please try again.', 'danger')
            return redirect(url_for('index.home'))
        else:
            reg_username = reg_username.lower()
            # if username is taken already.
            if reg_username in db_user.keys():
                flash('Username is taken. Please try again.', 'danger')
                return redirect(url_for('index.home'))

            # if confirm and not confirm are not equal, flash and return
            if reg_confirm_password != reg_password:
                flash('Passwords do not match. Please try again.', 'danger')
                return redirect(url_for('index.home'))

            # Else create the account
            new_user = Account(date(), reg_username, reg_name, reg_email,
                               reg_confirm_password, school='No school')
            db_user[reg_username] = new_user
            # Creating customer class for new user
            new_wallet = Customer(reg_username)
            db_wallet[reg_username] = new_wallet
            db_user.close()
            db_wallet.close()
            flash('Registered! You may now log in.', 'success')
            return redirect(url_for('index.home'))

    # redirection based on url and session id
    if '/home' in str(request.url_rule):
        if session['current_user'] == '':
            return render_template('index.html')
        elif session['current_user'] == 'ADMIN':
            return redirect(url_for('admin.admin_page'))
        else:
            return redirect(url_for('customer.overview'))
    elif '/about' in str(request.url_rule):
        if session['current_user'] == '':
            # Not signed in html does not have all navigation bar elements
            return render_template('about/not_signed_in.html')
        else:
            # Signed in html has all navigation bar elements for customer
            return render_template('about/signed_in.html')
    else:
        session['current_user'] = ''
        return render_template('index.html')
