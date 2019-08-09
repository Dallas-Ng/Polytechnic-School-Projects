//DALLAS' JAVASCRIPT FOR VENICE.HTML PAGE//

//GO TO TOP FUNCTION
function scrollFunction() {
    if (document.body.scrollTop > 300) {
        document.getElementById("GoToTopBtn").style.display = "block";
    } else {
        document.getElementById("GoToTopBtn").style.display = "none";
    }
}

window.onscroll = function() {scrollFunction()};

function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

//Board B
function Readmore() {
    var BoardBDots = document.getElementById("BoardBDots");
    var moreText = document.getElementById("BoardBReadMore");
    var btnText = document.getElementById("BoardBButton");
  
    if (BoardBDots.style.display === "none") {
      BoardBDots.style.display = "inline";
      btnText.innerHTML = "Read more"; 
      moreText.style.display = "none";
    } else {
      BoardBDots.style.display = "none";
      btnText.innerHTML = "Read less"; 
      moreText.style.display = "inline";
    }
  }

//BoardE
function infotab(food, Infoname) {
    var i, BoardEContent, BoardETabLink;
    BoardEContent = document.getElementsByClassName("BoardEContent");
    for (i = 0; i < BoardEContent.length; i++) {
        BoardEContent[i].style.display = "none";
    }
    BoardETabLink = document.getElementsByClassName("BoardETabLink");
    for (i = 0; i < BoardETabLink.length; i++) {
        BoardETabLink[i].className = BoardETabLink[i].className.replace(" active", "");
    }
    document.getElementById(Infoname).style.display = "block";
    evt.currentTarget.className += " active";
}

function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    h = checkTime(h-6);
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('clock').innerHTML =
    h + ":" + m + ":" + s;
    var t = setTimeout(startTime, 500);
}
function checkTime(i) {
    if (i < 10) {i = "0" + i};  // add zero in front of numbers < 10
    return i;
}

//BOARD H GOOGLE MAP // OBSOLETE IF USING HOSTING
function GoogleMap() {
    var mapProp= {
        center:new google.maps.LatLng(45.4367521,12.3345858),
        zoom:14,
    };
    var map=new google.maps.Map(document.getElementById("GoogleMap"),mapProp);
}

// FOOTER //I dont know how i broke it but i did
//Fix it by sometime :)
var page = document.getElementById('formbox');
window.onclick = function(event) {
    if (event.target == page) {
        page.style.display = "none";
    }
}



//SEARCH Function

var TRange=null;

function findString (str) {
 if (parseInt(navigator.appVersion)<4) return;
 var strFound;
 if (window.find) {

  // CODE FOR BROWSERS THAT SUPPORT window.find

  strFound=self.find(str);
  if (!strFound) {
   strFound=self.find(str,0,1);
   while (self.find(str,0,1)) continue;
  }
 }
 else if (navigator.appName.indexOf("Microsoft")!=-1) {

  // EXPLORER-SPECIFIC CODE

  if (TRange!=null) {
   TRange.collapse(false);
   strFound=TRange.findText(str);
   if (strFound) TRange.select();
  }
  if (TRange==null || strFound==0) {
   TRange=self.document.body.createTextRange();
   strFound=TRange.findText(str);
   if (strFound) TRange.select();
  }
 }
 else if (navigator.appName=="Opera") {
  alert ("Opera browsers not supported, sorry...")
  return;
 }
 if (!strFound) alert ("String '"+str+"' not found!")
 return;
}