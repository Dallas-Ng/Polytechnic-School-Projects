

## E- Business Website Documentation
Certcess is an online e-commerce education company that strives to deliver cheap and easily-digestable content to customers, so that they are able to save time and money



#### Required Nuget Packages: 
``Nuget install Twilo``

## Accounts
| Username | Password | Role |
|--|--|--|
| Admin | testtest | Admin|
| Dallas_Ng | testtest | Student |
| Teacher_Login | testtest | Teacher |
| MockDataUsername | testtest | ALL |

## Features

### Account System
```
All Account Types:
	1) Reset password through link
	2) Profile picture
		a) Previous profile picture is deleted when a new one is inputted
	3) Settings page
		a) Able to change basic information
		b) Able to delete account (Logical)
		c) Storable card details for payment
		d) Previous profile images gets deleted upon new profile image
	4) Lockout system for accounts
	5) Able to track course statistics
	6) Email system
		a) Sends email to new accounts
		b) Sends email when password is changed
		c) Sends email when teacher is approved
		d) Sends email when account gets locked
	7) One way hashing
		a) For passwords
		b) For payment card details
	8) Captcha for account creation to prevent botting or other security issues
	9) Custom error page that redirects based on session
	10) Users are able to talk to other users on forums (Using Emily's class)
		a) Shows basic information
	11) Users who deactivate their accounts are allowed to activate or sign up again.
	12) All pages are mobile friendly as well as has a go to top button
Customers:
	1) Logging in / Signing out
	2) Logging in and Signing out with Google OAuth2 API
	3) Able to purchase courses
		a) Double filters
	4) Recent login timestamp
Teachers:
	1) Documentation upload for teachers
Admins:
	a) Create new users
	b) Edit basic non-crucial information
	c) Approve teacher applications
	d) Delete users (Physical)
	e) Do real time searches on view page
	f) Double filter
	g) Check statistics
```

### Validations
```
1) All pages
	a) Checks if user is logged in
	b) Redirects back to index when session expires (60 minutes)
	c) Users are not allowed to go back to a page if they logged out (Pressing back button)
	d) Checks if user is allowed to view the page
		a) Teachers are not allowed to be on users page, vice versa
		b) Teachers and Users are not allowed on Admin pages
		c) Admins are allowed on both teachers and users pages
2) Sign up page
	a) Checks if login id exists
	b) Checks if email exists
	c) Checks if username is in reservedUsernames
	d) Checks if passwords matches
	e) Checks if captcha is validated
3) Sign in page
	a) account exists
	b) Checks if account is logically deleted
	c) Checks if account is locked out
	d) checks if password matches database stored hash
4) Google sign in
	a) Checks if email currently exists
		i) If email not existed, go to sign up page
5) Sign up Teacher
	a) Checks if email exists
	b) Checks file upload exists
	c) Checks if captcha is validated
6) Links and Tokens generated
	*Generated when*
		*Users request for new password*
		*Teachers approved*
		*Google logins*
		*Confirm email*
	a) Tokens are locked depending on security level
	b) Checks if tokens exists in the database
7) Confirm Password
	a) Checks if old password hash matches stored hash
	b) Checks if new passwords match
8) Sign up reactivation
	a) Prevents user from creating accounts with a used email besides their own
		i) When user creates a new account they are allowed to reuse the email, 
			this prevents the user from reusing other emails
9) Shop/Courses
	a) Removes any courses already enrolled by the user
```
