"""
Written by:
Dallas 180522Y
"""
from flask import Flask, render_template
from flask_bootstrap import Bootstrap

# Main
from main_apps.front_end.main import index

# Front End
from main_apps.front_end.booking import booking
from main_apps.front_end.booking_extended import booking_ext
from main_apps.front_end.customer import customer
from main_apps.front_end.customer_extended import customer_ext

# Back end
from main_apps.back_end.account import account

# Admin Pages
from main_apps.back_end.admin.admin import admin
from main_apps.back_end.admin.admin_booking import dev_booking
from main_apps.back_end.admin.admin_feedback import dev_feedback
from main_apps.back_end.admin.admin_reminder import dev_registered
from main_apps.back_end.admin.admin_overview import dev_overview

from main_apps.back_end.support import support

# Config
from main_apps.config import Config

app = Flask(__name__)
Bootstrap(app)
app.config.from_object(Config)

# Main
app.register_blueprint(index)

# Front End
app.register_blueprint(booking)
app.register_blueprint(booking_ext)
app.register_blueprint(customer)
app.register_blueprint(customer_ext)

# Back End
app.register_blueprint(account)

# Admin pages
app.register_blueprint(admin)
app.register_blueprint(dev_booking)
app.register_blueprint(dev_feedback)
app.register_blueprint(dev_registered)
app.register_blueprint(dev_overview)

app.register_blueprint(support)


@app.errorhandler(404)
def page_not_found(error):
    return render_template('library_html/404.html'), 404


@app.errorhandler(500)
def page_internal_error(error):
    return render_template('library_html/500.html'), 500
