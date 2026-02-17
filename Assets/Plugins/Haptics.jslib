mergeInto(LibraryManager.library, {
  TriggerIOSHaptic: function() {
    try {
      var labelEl = document.createElement("label");
      labelEl.ariaHidden = "true";
      labelEl.style.display = "none";

      var inputEl = document.createElement("input");
      inputEl.type = "checkbox";
      inputEl.setAttribute("switch", "");

      labelEl.appendChild(inputEl);
      document.head.appendChild(labelEl);
      labelEl.click();
      document.head.removeChild(labelEl);
    } catch(e) {}
  },

  TriggerAndroidHaptic: function(duration) {
    if (navigator.vibrate) {
      navigator.vibrate(duration);
    }
  }
});