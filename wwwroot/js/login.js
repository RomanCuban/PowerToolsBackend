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

// Set up our login function
function login() {
  // Get all our input fields
  var email = document.getElementById("email").value;
  var password = document.getElementById("password").value;

  // Validate input fields
  if (validate_email(email) == false || validate_password(password) == false) {
    alert("Email or Password is Outta Line!!");
    return;
    // Don't continue running the code
  }

  auth
    .signInWithEmailAndPassword(email, password)
    .then(function () {
      // Redirect to homepage after successful login
      window.location.href = "/html/homepage.html";

      // Hide the login link and show the user button
      var navSignLink = document.querySelector(".nav-links .nav-sign");
      var userButton = document.querySelector(".nav-links .user");
      if (navSignLink && userButton) {
        navSignLink.style.display = "none"; // Hide nav-sign link
        userButton.style.display = "block"; // Show user button
      }
    })
    .catch(function (error) {
      // Handle Errors here.
      var errorCode = error.code;
      var errorMessage = error.message;
      alert(errorMessage);
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
