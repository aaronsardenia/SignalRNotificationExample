console.log("loaded");

console.log(window.location.href);

let urlArray = window.location.href.split("/");
let pageName = urlArray[3];


//render click effect on navbar
switch (pageName) {
    case "History.aspx":
        console.log("history.aspx");
        break;
    case "Payment.aspx":
        console.log("Payment.aspx");
        break;
    case "Recipients.aspx":
        console.log("Recipients.aspx");
        break;
}





$(".nav-link").click((e) => {
    //e.preventDefault();

    let div = document.createElement("div");
    div.textContent = "hi";

    //e.target.append(div);

    console.log("clickedd");
    let active = $(e.target).hasClass("active");

});


/*
  // For some browsers, `attr` is undefined; for others, `attr` is false. Check for both.
    if (typeof active == typeof undefined || active == false) {
        console.log(e.target);
        console.log("after target");
        console.log($(e.target).siblings());
        $(e.target).siblings().each((index, element) => {
            if ($(element).hasClass("active"))
                $(element).removeClass("active");
        });

        $(e.target).addClass("active");
        console.log("add active.");
    }
    else if (active != undefined || active == true) {
        $(e.target).removeClass("active");
        console.log("remove active.");

    }
 
 */

