/* ========================================================
*
* MVP Ready - Lightweight & Responsive Admin Template
*
* ========================================================
*
* File: mvpready-admin.js
* Theme Version: 3.0.0
* Bootstrap Version: 3.3.6
* Author: Jumpstart Themes
* Website: http://mvpready.com
*
* ======================================================== */

var mvpready_admin = function () {

  "use strict"

  return {
    init: function () {
      // Layouts
      mvpready_core.initNavEnhanced ()
      mvpready_core.initNavHover ({ delay: { show: 250, hide: 350 } })

      mvpready_core.initNavbarNotifications ()
      mvpready_core.initLayoutToggles ()
      mvpready_core.initBackToTop ()

      // Components
      mvpready_helpers.initAccordions ()
      mvpready_helpers.initFormValidation ()
      mvpready_helpers.initTooltips ()
      mvpready_helpers.initLightbox ()
      mvpready_helpers.initSelect ()
      mvpready_helpers.initIcheck ()
      mvpready_helpers.initDataTableHelper ()
      mvpready_helpers.initiTimePicker ()
      mvpready_helpers.initDatePicker ()
      mvpready_helpers.initColorPicker ()
    }
  }

}()

$(function () {
  mvpready_admin.init ()
})