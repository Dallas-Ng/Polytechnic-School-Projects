"""
Written by:
Dallas 180522Y
Randy 181773X
"""
from properties.external.shelving.inherit import *
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
import datetime


class Customer(InheritThis):
    def __init__(self, username):
        super().__init__(username)
        self.__points = 0
        self.__wallet = 0
        self.__credit_card = ''
        self.__card_name = ''
        self.__card_expire_date = ''

        # ACCESSOR ================================================================

    def get_points(self):
        return self.__points

    def get_wallet(self):
        return self.__wallet

    def get_credit_card(self):
        return self.__credit_card

    def get_card_name(self):
        return self.__card_name

    def get_card_expire_date(self):
        return self.__card_expire_date

        # MUTATOR ================================================================

    def set_points(self, points):
        self.__points = points

    def set_wallet(self, amount):
        self.__wallet = amount

    def set_credit_card(self, card):
        self.__credit_card = card

    def set_card_name(self, name):
        self.__card_name = name

    def set_card_expire_date(self, date):
        self.__card_expire_date = date

        # FUNCTIONS ================================================================
        # POINTS ======================================================

    def points_deduct(self, deduct):
        self.__points -= deduct

    def points_add(self, add):
        self.__points += int(add)

        # WALLET ======================================================

    def wallet_withdraw(self, withdraw):
        self.__wallet -= withdraw

    def wallet_deposit(self, deposit):
        self.__wallet += int(deposit)


class Transaction(InheritThis):
    def __init__(self, username, deposit):
        super().__init__(username)

        wallet_trans_id = str(datetime.datetime.now().timestamp())
        date = datetime.datetime.now().strftime('%Y-%m-%d %X')
        self.__wallet_trans_id = wallet_trans_id
        self.__deposit = deposit
        self.__date = date

    def get_transaction_id(self):
        return self.__wallet_trans_id

    def get_deposit(self):
        return self.__deposit

    def get_date(self):
        return self.__date


class AdminTransaction(InheritThis):
    def __init__(self, username, withdraw):
        super().__init__(username)

        wallet_withdraw_id = str(datetime.datetime.now().timestamp())
        points_trans_id = str(datetime.datetime.now().timestamp())
        date = datetime.datetime.now().strftime('%Y-%m-%d %X')
        self.__wallet_withdraw_id = wallet_withdraw_id
        self.__points_trans_id = points_trans_id
        self.__withdraw = withdraw
        self.__date = date

    def get_wallet_withdraw_id(self):
        return self.__wallet_withdraw_id

    def get_points_trans_id(self):
        return self.__points_trans_id

    def get_withdraw(self):
        return self.__withdraw

    def get_date(self):
        return self.__date
