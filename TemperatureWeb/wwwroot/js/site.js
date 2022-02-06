// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let btn = document.querySelector("#btn");
let from = document.querySelector("#from");
let to = document.querySelector("#to");
let value = document.querySelector("#value");

from.value = localStorage.getItem("from");
to.value = localStorage.getItem("to");
value.value = localStorage.getItem("value");


btn.addEventListener("click", conversion);

function conversion() {
  localStorage.setItem("to", to.value);
  localStorage.setItem("from", from.value);
  localStorage.setItem("value", value.value);
}
