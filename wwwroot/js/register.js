// Your web app's Firebase configuration
var firebaseConfig = {
  apiKey: "AIzaSyCLfpbjtP64oAy7Qf1Ta5LMQ8AwE4znyNM",
  authDomain: "power-tools-kz.firebaseapp.com",
  databaseURL: "https://power-tools-kz-default-rtdb.firebaseio.com/",
  projectId: "power-tools-kz",
  storageBucket: "power-tools-kz.appspot.com",
  messagingSenderId: "231813595317",
  appId: "1:231813595317:web:c3d6e264defc5995e7befc",
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

// Initialize variables
const auth = firebase.auth();
const database = firebase.database();

// Set up our register function
function register() {
  // Get all our input fields
  var email = document.getElementById("email").value;
  var password = document.getElementById("password").value;
  var username = document.getElementById("username").value;
  // Validate input fields
  if (
    validate_email(email) == false ||
    validate_password(password) == false ||
    validate_field(username) == false
  ) {
    alert("Username or Email or Password is Outta Line!!");
    return;
    // Don't continue running the code
  }

  // Move on with Auth
  auth
    .createUserWithEmailAndPassword(email, password)
    .then(function () {
      // Declare user variable
      var user = auth.currentUser;

      // Add this user to Firebase Database
      var database_ref = database.ref();

      // Create User data
      var user_data = {
        email: email,
        username: username,
        last_login: Date.now(),
      };

      // Push to Firebase Database
      database_ref.child("users/" + user.uid).set(user_data);

      // Redirect to login page after successful registration
      window.location.href = "/html/login.html";

      // Done
      alert("User Created!!");
    })
    .catch(function (error) {
      // Firebase will use this to alert of its errors
      var error_code = error.code;
      var error_message = error.message;

      alert(error_message);
    });
}

// Validate Functions
function validate_email(email) {
  expression = /^[^@]+@\w+(\.\w+)+\w$/;
  if (expression.test(email) == true) {
    // Email is good
    return true;
  } else {
    // Email is not good
    return false;
  }
}

function validate_password(password) {
  // Firebase only accepts lengths greater than 6
  if (password.length < 6) {
    return false;
  } else {
    return true;
  }
}

function validate_field(field) {
  if (field == null) {
    return false;
  }

  if (field.length <= 0) {
    return false;
  } else {
    return true;
  }
}
