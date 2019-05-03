<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="NotificationTest.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--sets the width of the page to follow the screen-width of the device -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <link href="assets/css/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous" />


    <style type="text/css">
        /*Added css for design notification area, you can design by your self*/
        /* COPY css content from youtube video description*/
        .noti-content {
            position: fixed;
            right: 100px;
            background: #e5e5e5;
            border-radius: 4px;
            top: 47px;
            width: 250px;
            display: none;
            border: 1px solid #9E988B;
        }

        ul#notiContent {
            max-height: 200px;
            overflow: auto;
            padding: 0px;
            margin: 0px;
            padding-left: 20px;
        }

            ul#notiContent li {
                margin: 3px;
                padding: 6px;
                background: #fff;
            }

        .noti-top-arrow {
            border-color: transparent;
            border-bottom-color: #F5DEB3;
            border-style: dashed dashed solid;
            border-width: 0 8.5px 8.5px;
            position: absolute;
            right: 32px;
            top: -8px;
        }

        span.noti {
            color: #FF2323;
            margin: 15px;
            position: fixed;
            right: 100px;
            font-size: 18px;
            cursor: pointer;
        }

        span.count {
            position: relative;
            top: -3px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <span class="glyphicon glyphicon-bell"></span>
        <span class="noti glyphicon glyphicon-bell"><span class="count">&nbsp;bell</span></span>
        <!--hidden-->
        <div class="noti-content">
            <div class="noti-top-arrow"></div>
            <ul id="notiContent">


                <li>test</li>
            </ul>
        </div>

    </form>

    <!--    <script src="Scripts/jquery-1.6.4.min.js"></script>-->

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src="/signalr/js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <script type="text/javascript">


        $(function () {
            /* signalr js code for start hub and send receive notification.
             * In JavaScript the reference to the server class and its members has to be camelCase. 
             * The code sample references the C# ChatHub class in JavaScript as chatHub.
             * docs:https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/tutorial-getting-started-with-signalr
             */

            var notificationHub = $.connection.notificationHub;
            var id = "123";

            //add querystring to hub before starting the hub to ensure default useridprovider is not used. 
            var hub = $.connection.hub;
            hub.qs = { 'id': id };

            notificationHub.client.notify = function (message) {
                alert("message");
                console.log("added");
                if (message && message.toLowerCase() == "added") {
                    console.log("signr notify invoked");
                    updateNotificationCount();

                    //change value of show to specific client
                    notificationHub.server.show(id);
                }
            }


            // SignalR server invoke c
            notificationHub.client.displayStatus = function (message) {
                console.log("displayStatus invoked");
                console.log(message);
                updateNotification();
            }

            // Click on notification icon for show notification
            $('span.noti').click(function (e) {
                e.stopPropagation();
                console.log("clicked span.noti");
                $('.noti-content').show();
                var count = 0;


                updateNotification();


            })
            // hide notifications
            $('html').click(function () {
                $('.noti-content').hide();
            })
            // update notification
            function updateNotification() {
                $('#notiContent').empty();
                // $('#notiContent').append($('<li>Loading...</li>'));
                $.ajax({
                    type: "POST",
                    url: 'test.aspx/getobject',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log("Response is:");
                        console.log(response);
                        //$('#notiContent').empty();


                        span = document.createElement("span");
                        divElement = document.createElement("div");
                        $(divElement).append(span);
                        $(span).text = "Updated value is: " + response.ledger;

                        $('#notiContent').append(divElement);
                    },
                })
            }
            // update notification count
            function updateNotificationCount() {
                var count = 0;
                count = parseInt($('span.count').html()) || 0;
                count++;
                $('span.count').html(count);
            }
            //    $.connection.hub.qs = "id=" + useridentifier;



            $.connection.hub.start().done(function () {
                // notificationHub.server.cacheUserId(useridentifier);
                console.log('Notification hub started');
            });


        });
    </script>

</body>
</html>
