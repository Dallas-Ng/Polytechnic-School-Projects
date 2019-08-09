"""
Written by:
Dallas 180522Y
Randy 181773X
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session, Markup
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

customer_ext = Blueprint('customer_ext', __name__)


@customer_ext.route('/overview_wallet/', methods=['GET', 'POST'])
def overview_wallet():
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    points_amount = retrieve_customer(session['current_user'], 'points')
    user_data = access_database('accounts', 'accounts')

    wallet_transaction_list = []
    db = access_database('currency', 'trans_history')
    for key in db.keys():
        if db[key].get_username() == session['current_user']:
            if db[key].get_transaction_id() not in wallet_transaction_list:
                wallet_transaction_list.append(db[key])

    obj = user_data[session['current_user']]
    recent_login = obj.get_last_seen()

    wallet_transaction_list.sort(key=lambda x: (x.get_date()), reverse=True)
    return render_template('overview/wallet/wallet.html',  wallet_list=wallet_transaction_list,
                           user=session['current_user'][0].upper()+session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount, points_amount=points_amount,
                           user_data=user_data[session['current_user']])


@customer_ext.route('/overview_top_up/', methods=['GET', 'POST'])
def overview_top_up():
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    form = TopUp(request.form)

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    points_amount = retrieve_customer(session['current_user'], 'points')
    user_data = access_database('accounts', 'accounts')
    user_customer = access_database('currency', 'currency')

    obj = user_data[session['current_user']]
    card = user_customer[session['current_user']]
    recent_login = obj.get_last_seen()
    cardnumber = card.get_credit_card()

    if cardnumber == '':
        cardnumber = 'You have not add a credit card yet.'

    if request.method == 'POST':
        if form.validate():
            if user_customer[session['current_user']].get_credit_card() != '':
                amount = form.top_up.data
                access_customer(session['current_user'], 'points', amount * 10)
                access_customer(session['current_user'], 'wallet', amount)

                db_currency = access_database('currency', 'trans_history')
                obj = Transaction(session['current_user'], amount)
                db_currency[obj.get_transaction_id()] = obj

            else:
                flash('You have not assigned a credit card', 'danger')
            return redirect(url_for('customer_ext.overview_wallet'))
    return render_template('overview/wallet/wallet_top_up.html', form=form,
                           # This is for the left side !! DONT TOUCH !!
                           user=session['current_user'][0].upper()+session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount, points_amount=points_amount,
                           user_data=user_data[session['current_user']], cardnumber=cardnumber)


@customer_ext.route('/add_creditcard/', methods=['GET', 'POST'])
def add_creditcard():
    if session['current_user'] == '':
        return redirect(url_for('index.home'))

    form = AddingCreditCard(request.form)

    wallet_amount = retrieve_customer(session['current_user'], 'wallet')
    points_amount = retrieve_customer(session['current_user'], 'points')
    user_data = access_database('accounts', 'accounts')
    user_wallet = access_database('currency', 'currency')

    obj = user_data[session['current_user']]
    recent_login = obj.get_last_seen()

    wallet = user_wallet[session['current_user']]
    card_number = wallet.get_credit_card()
    card_holder_name = wallet.get_card_name()
    card_expire_date = wallet.get_card_expire_date()

    if not card_expire_date:
        card_expire_date = 'MM / YYYY'

    if request.method == 'POST':
        new_card_number = request.form.get('card_number', False)
        new_card_holder_name = request.form.get('card_holder_name', False)
        new_card_expire_date = request.form.get('expire_date', False)

        if new_card_number:
            wallet.set_credit_card(new_card_number)
            wallet.set_card_name(new_card_holder_name)
            wallet.set_card_expire_date(new_card_expire_date)
            user_wallet[session['current_user']] = wallet

        flash('Card Updated', 'success')
        return redirect(url_for('customer_ext.add_creditcard'))
    return render_template('overview/wallet/wallet_add_card.html', form=form,
                           # Credit Card
                           card_number=card_number, card_holder_name=card_holder_name,
                           card_expire_date=card_expire_date,
                           # For the left side of the page !!DONT TOUCH!!
                           user=session['current_user'][0].upper()+session['current_user'][1:].lower(),
                           recent_login=recent_login,
                           wallet_amount=wallet_amount, points_amount=points_amount,
                           user_data=user_data[session['current_user']])


