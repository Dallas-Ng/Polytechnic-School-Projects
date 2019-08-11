"""
Written by:
Dallas 180522Y
Tjandra 181110B
Faris 182915N
"""
from properties.external.shelving.inherit import *
from properties.external.library_python.functions import *
from properties.external.library_python.form import *
import datetime


class Feedback(InheritThis):
    def __init__(self, username, booking_id, cleanliness, punctuality, faulty, vandalism, map, payment, account, aesthetic):
        super().__init__(username)

        feedback_id = str(datetime.datetime.now().timestamp())
        self.__feedback_id = feedback_id

        self.__booking_id = booking_id

        time_now = datetime.datetime.now()

        # Get Month
        feedback_month = time_now.strftime('%B')
        self.__feedback_month = feedback_month

        # Get Year
        feedback_year = time_now.strftime('%Y')
        self.__feedback_year = feedback_year

        # Time
        creation_date = time_now.strftime('%d/%m/%Y %X')
        self.__creation_date = creation_date

        # Important
        self.__important = False

        # Form Actions
        self.__cleanliness = cleanliness
        self.__punctuality = punctuality
        self.__faulty = faulty
        self.__vandalism = vandalism
        self.__map = map
        self.__payment = payment
        self.__account = account
        self.__aesthetic = aesthetic

    # ACCESSOR ================================================================
    def get_booking_id(self):
        return self.__booking_id

    def get_feedback_id(self):
        return self.__feedback_id

    def get_cleanliness(self):
        return self.__cleanliness

    def get_punctuality(self):
        return self.__punctuality

    def get_faulty(self):
        return self.__faulty

    def get_vandalism(self):
        return self.__vandalism

    def get_map(self):
        return self.__map

    def get_payment(self):
        return self.__payment

    def get_account(self):
        return self.__account

    def get_aesthetic(self):
        return self.__aesthetic

    # MUTATOR ================================================================
    def set_year(self, year):
        self.__feedback_year = year

    def set_month(self, month):
        self.__feedback_month = month

    def set_booking_id(self, booking_id):
        self.__booking_id = booking_id

    # FUNCTIONS ================================================================
    def set_important(self):
        self.__important = True

    def remove_important(self):
        self.__important = False

    def get_month(self):
        return self.__feedback_month

    def get_year(self):
        return self.__feedback_year

    def get_creation_date(self):
        return self.__creation_date

    def get_information(self):
        string = 'Clean = %s, Punctuality = %s, Faulty = %s, Vandalism = %s, Map = %s, Payment = %s, ' \
                 'Account = %s, Aesthetics = %s' % (self.__cleanliness, self.__punctuality,
                                                    self.__faulty, self.__vandalism, self.__map, self.__payment,
                                                    self.__account, self.__aesthetic)
        return string
