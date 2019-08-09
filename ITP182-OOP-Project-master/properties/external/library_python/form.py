"""
Written by:
Dallas 180522Y
Randy 181773X
Tjandra 181110B
Faris 182915N
"""
from wtforms import Form, BooleanField, StringField, PasswordField, \
                    SubmitField, RadioField, validators, SelectField, IntegerField, DateField, widgets
from wtforms.validators import *
from wtforms.fields.html5 import *


# CUSTOMER =========================================================================================================
class Particulars(Form):
    name = StringField('Name')
    email = EmailField('Email', validators=[Email()])
    password = PasswordField('Password', validators=[EqualTo('confirm_password', 'Passwords must be the same')])
    confirm_password = PasswordField('Confirm Password')
    school = SelectField('School', choices=[('No changes', 'No Changes'), ('NYP', 'Nanyang poly'),
                                            ('TP', 'Temasek Poly'), ('SP', 'Singapore Poly')])
    submit = SubmitField('Edit')


# BOOKING ==========================================================================================================
class BookingForm(Form):
    location = SelectField('Pick up location', choices=[('Yishun', 'Yishun'), ('Woodlands', 'Woodlands'), ('Sembawang', 'Sembawang'), ('Yio Chu Kang', 'Yio Chu Kang')], validators=[InputRequired()])
    date = StringField(id='datepicker', validators=[InputRequired()])
    time = StringField(id='timepicker', validators=[InputRequired()])
    submit = SubmitField('Create booking')


class EditBookingForm(Form):
    location = SelectField('Pick up location', choices=[('Yishun', 'Yishun'), ('Woodlands', 'Woodlands'), ('Sembawang', 'Sembawang'), ('Yio Chu Kang', 'Yio Chu Kang')])
    date = StringField(id='datepicker')
    time = StringField(id='timepicker')
    submit = SubmitField('Edit booking')


# WALLET ============================================================================================================
class TopUp(Form):
    top_up = IntegerField('Top up amount', validators=[input_required()])
    ccv = StringField('Enter your CCV', validators=[input_required(), length(min=3, max=3, message='Please enter a valid CCV')])
    submit = SubmitField('Top up!')


class AddingCreditCard(Form):
    creditcard = StringField('Type in your credit card number.', validators=[input_required(), Length(max=16, message='Please Enter a valid Credit Card Number')])
    ccv = StringField('CCV', validators=[input_required(), Length(min=3, max=3, message='Please Enter a valid CCV')])
    submit = SubmitField('Add Card')


# ADMIN ===================================================================================================
class AdminModify(Form):
    username = StringField('Type in the Username')
    deposit = IntegerField('Wallet: Deposit')
    withdraw = IntegerField('Wallet: Deducting')
    add = IntegerField('Points: Adding')
    deduct = IntegerField('Points: Deducting')
    submit = SubmitField('Submit')


class AdminFeedback(Form):
    important = BooleanField('Important')
    month = SubmitField('Month')
    year = SubmitField('Year')


class AdminReminder(Form):
    info = StringField('Reminder', [validators.InputRequired()])
    name = StringField('Admin Name', [validators.InputRequired()])


# FEEDBACK ==================================================================================================
class FeedbackForm(Form):
    cleanliness = RadioField('How clean was your car?', choices=[('Very clean', 'Very clean'), ('Clean', 'Clean'),
                                                                 ('Average', 'Average'), ('Dirty', 'Dirty'),
                                                                 ('Very Dirty', 'Very Dirty')],
                             validators=[input_required()])

    punctuality = RadioField('How punctual was your ride?', choices=[('Very early', 'Very early'), ('Early', 'Early'),
                                                                     ('On time', 'On time'), ('Late', 'Late'),
                                                                     ('Very Late', 'Very Late')],
                             validators=[input_required()])

    faulty = RadioField('Was there any faulty equipment in the car?', choices=[('Yes', 'Yes'), ('No', 'No')],
                        validators=[input_required()])

    vandalism = RadioField('Was there any vandalism found in the car?', choices=[('Yes', 'Yes'), ('No', 'No')],
                           validators=[input_required()])

    map = RadioField('Was the map accurate to your location pick-up?', choices=[('Yes', 'Yes'), ('No', 'No')],
                     validators=[input_required()])

    payment = RadioField('Do you face any trouble with payment issue?', choices=[('Yes', 'Yes'), ('No', 'No')],
                         validators=[input_required()])

    account = RadioField('Do you face any trouble with your account?', choices=[('Yes', 'Yes'), ('No', 'No')],
                         validators=[input_required()])

    aesthetic = RadioField('Is our website aesthetically appealing to you?'
                           ' e.g. minimal design, easy to understand/navigate', choices=[('Yes', 'Yes'), ('No', 'No')],
                           validators=[input_required()])

    submit = SubmitField('Send Feedback')


# LOST AND FOUND
class LostAndFoundForm(Form):
    status = StringField('Name: ', validators=[input_required()])
    date = StringField('Date: ', validators=[InputRequired()])
    time = StringField('Time: ', validators=[InputRequired()])
    item = StringField('Item lost: ', validators=[input_required()])
    description = StringField('Description: ', validators=[input_required()])
    submit = SubmitField('Send Form')



