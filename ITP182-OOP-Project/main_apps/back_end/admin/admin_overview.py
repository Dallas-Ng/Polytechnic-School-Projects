"""
Written by:
Dallas 180522Y
Randy 181773X
"""
from flask import Blueprint, Flask, render_template, redirect, request, url_for, flash, session
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
from properties.external.shelving.shelving import *

dev_overview = Blueprint('dev_overview', __name__)


@dev_overview.route('/admin_overview/', methods=['GET', 'POST'])
def admin_overview():
    customer_list = retrieve_database('currency', 'currency')
    return render_template('admin/admin_customer_overview.html', list=customer_list)


@dev_overview.route('/admin_overview_edit_balances/<user>/', methods=['GET', 'POST'])
def admin_overview_edit_balances(user):
    form = AdminModify(request.form)
    if request.method == 'POST':
        db_wallet = access_database('currency', 'currency')

        obj = db_wallet[user]

        if form.deposit.data:
            obj.wallet_deposit(form.deposit.data)

        if form.withdraw.data and form.withdraw.data <= obj.get_wallet():
            obj.wallet_withdraw(form.withdraw.data)
        else:
            if form.withdraw.data:
                flash(obj.get_username()+' do not have sufficient funds','danger')

        if form.add.data:
            obj.points_add(form.add.data)

        if form.deduct.data and form.deduct.data <= obj.get_points():
            obj.points_deduct(form.deduct.data)
        else:
            if form.deduct.data:
                flash(obj.get_username()+' have insufficient points','danger')

        db_wallet[user] = obj
        db_wallet.close()
        return redirect(url_for('dev_overview.admin_overview'))

    wallet_balance = retrieve_customer(user, 'wallet')
    points_balance = retrieve_customer(user, 'points')

    return render_template('admin/admin_overview_edit_balances.html', form=form, user=user, wallet=wallet_balance, points=points_balance)


def admin_transaction():
    form = AdminModify(request.form)
    if request.method == 'POST':
        wallet_withdraw = form.withdraw.data

        access_customer(session['current_user'], 'wallet', wallet_withdraw)
        db = access_database('currency', 'trans_history')
        obj = AdminTransaction(session['current_user'], wallet_withdraw)
        db[obj.get_wallet_withdraw_id()] = obj
        db.close()
