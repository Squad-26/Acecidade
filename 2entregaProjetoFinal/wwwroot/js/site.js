// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {
  'use strict';
  window.addEventListener('load', function () {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName('needs-validation');
    // Loop over them and prevent submission
    var validation = Array.prototype.filter.call(forms, function (form) {
      form.addEventListener('submit', function (event) {
        if (form.checkValidity() === false) {
          event.preventDefault();
          event.stopPropagation();
        }
        form.classList.add('was-validated');
      }, false);
    });
  }, false);
})();

function handleCredentialResponse(response) {
  const data = jwt_decode(response.credential) 
  console.log(data)
}
window.onload = function () {
  google.accounts.id.initialize({
    client_id: "1064343277548-vprmt852g7lfju46nm5b4513vrq1cnlh.apps.googleusercontent.com",
    callback: handleCredentialResponse
  });
  google.accounts.id.renderButton(
    document.getElementById("buttonDiv"),
    {
     type: "icon",
     shape: "square",
     theme: "outline",
     text: "$ {button.text}",
     size: "large"
    }  // customization attributes
  );
  google.accounts.id.prompt(); // also display the One Tap dialog
}

