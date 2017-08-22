// A javascript event listener built for a Chrome Extension. The script uses chrome-extension event interface to plug into
// the event loop. 
// Custom event handler are in place, producing a "navigational map". Outputs are used to generate functional automated tests.

function PageEvent(event) {
  this.tab_id = event.tabId;
  this.location = event.url ? event.url : "not_available";
  this.content = "";
  this.name = event.name;
  this.triggeredAt = new Date().toString();

  // If the event expose transition data, adds it to the collection of 
  // page transitions
  this.transitions = event.transitionType ? [ new PageTransition(event) ] : [];
  this.snapshot = "";  
}

function PageTransition (event) {
  this.triggeredAt = new Date().toString();
  this.origin = "";
  this.target = event.url ? event.url : "not_available";
  this.cause = event.transitionType ? event.transitionType : "not_available";
  this.category = event.transitionQualifiers ? event.transitionQualifiers : "not_available";
}

// Page event handlers

onBeforeNavigate = function (event) {
  event.name = "onBeforeNavigate";
  var e = new PageEvent(event);
  handlePageEvent(e);
};

onCommitted = function (event) {
  event.name = "onCommitted";
  var e = new PageEvent(event);
  handlePageEvent(e);
};

onDOMContentLoaded = function (event) {
  event.name = "onDOMContentLoaded";
  var e = new PageEvent(event);
  handlePageEvent(e);
};

onCompleted = function (event) {
  event.name = "onCompleted";
  var e = new PageEvent(event);
  handlePageEvent(e);
};

onErrorOccurred = function (event) {
  event.name = "onErrorOccurred";
  var e = new PageEvent(event);
  handlePageEvent(e);
};

onReferenceFragmentUpdated = function (event) {
  event.name = "onReferenceFragmentUpdated";
  var e = new PageEvent(event);
  handlePageEvent(e);
};

// A pseudo-class that is used to listen/mute page events
function NavigationMonitor(options) {
  this.options = options;

  // status: 0 -> mute , 1 -> listening
  this.status = 0;

  this.listen = function() {

    this.status = 1;

    var options = this.options;

    chrome.webNavigation.onBeforeNavigate.addListener( onBeforeNavigate, options);
    chrome.webNavigation.onCommitted.addListener( onCommitted, options);
    chrome.webNavigation.onDOMContentLoaded.addListener( onDOMContentLoaded, options);
    chrome.webNavigation.onCompleted.addListener( onCompleted, options);
    chrome.webNavigation.onErrorOccurred.addListener( onErrorOccurred, options);
    chrome.webNavigation.onReferenceFragmentUpdated.addListener( onReferenceFragmentUpdated, options);
  };

  this.mute = function() {

    this.status = 0;

    var options = this.options;

    chrome.webNavigation.onBeforeNavigate.removeListener( onBeforeNavigate, options);
    chrome.webNavigation.onCommitted.removeListener( onCommitted, options);
    chrome.webNavigation.onDOMContentLoaded.removeListener( onDOMContentLoaded, options);
    chrome.webNavigation.onCompleted.removeListener( onCompleted, options);
    chrome.webNavigation.onErrorOccurred.removeListener( onErrorOccurred, options);
    chrome.webNavigation.onReferenceFragmentUpdated.removeListener( onReferenceFragmentUpdated, options);
  };

}