"""
Written by:
Dallas 180522Y
"""
from properties.external.shelving.inherit import *
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
import datetime


class Account(InheritThis):
    def __init__(self, seen, username, name, email, password, school):
        super().__init__(username)

        # Changing Variables
        self.__last_seen = seen
        self.__sign_in = ''

        self.__account_creation_date = date()
        self.__account_premium = False
        self.__account_premium_date = ''

        # Sign up Information
        self.__name = name
        self.__email = email
        self.__password = password
        self.__school = school

    # ACCESSOR ================================================================
    def get_last_seen(self):
        return self.__last_seen

    def get_sign_in(self):
        return self.__sign_in

    def get_account_creation_date(self):
        return self.__account_creation_date

    def get_premium_status(self):
        return self.__account_premium

    def get_premium_date(self):
        return self.__account_premium_date

    def get_name(self):
        return self.__name

    def get_email(self):
        return self.__email

    def get_password(self):
        return self.__password

    def get_school(self):
        return self.__school

    # MUTATOR ================================================================
    def set_premium(self):
        self.__account_premium = True

    def set_premium_date(self):
        self.__account_premium_date = date()

    def set_name(self, new_name):
        self.__name = new_name
        return self.__name

    def set_email(self, new_email):
        self.__email = new_email
        return self.__email

    def set_password(self, new_password):
        self.__password = new_password
        return self.__password

    def set_school(self, new_school):
        self.__school = new_school
        return self.__school

    # FUNCTIONS ================================================================
    def update_last_seen(self, seen):
        self.__last_seen = seen

    def update_sign_in(self, sign):
        self.__sign_in = sign

    def reset_password(self):
        self.__password = ''
