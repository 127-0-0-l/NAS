// light theme colors
const header_background_color_light = '#126d91';
const header_color_light = 'white';
const theme_toggle_background_color_light = '#24292e';
const theme_toggle_color_light = 'white';
const body_background_color_light = '#FFF';
const body_color_light = 'black';
const page_content_background_color_light = '#FFF';
const page_content_color_light = 'black';
const sidebar_menu_background_color_light = '#f1f1f1';
const sidebar_menu_a_color_light = 'black';
const sidebar_menu_a_active_background_color_light = '#1098c1';
const sidebar_menu_a_active_color_light = 'white';
const sidebar_menu_a_hover_background_color_light = '#555';
const sidebar_menu_a_hover_color_light = 'white';
const tab_content_background_color_light = '#FFF';
const tab_content_color_light = 'black';
const sidebar_monitor_background_color_light ='#f1f1f1';
const sidebar_monitor_color_light = 'black';
const monitor_log_background_color_light = '#f1f1f1';
const monitor_log_color_light = 'black';
const monitor_queue_background_color_light = '#d7d7d7';
const monitor_queue_color_light = 'black';

// dark theme colors
const header_background_color_dark = '#24292e';
const header_color_dark = 'white';
const theme_toggle_background_color_dark = '#126d91';
const theme_toggle_color_dark = 'white';
const body_background_color_dark = 'black';
const body_color_dark = 'white';
const page_content_background_color_dark = 'black';
const page_content_color_dark = 'white';
const sidebar_menu_background_color_dark = '#313742';
const sidebar_menu_a_color_dark = '#aab1bb';
const sidebar_menu_a_active_background_color_dark = '#04AA6D';
const sidebar_menu_a_active_color_dark = 'white';
const sidebar_menu_a_hover_background_color_dark = '#eee';
const sidebar_menu_a_hover_color_dark = 'black';
const tab_content_background_color_dark = '#404552';
const tab_content_color_dark = '#fbfbfe';
const sidebar_monitor_background_color_dark = ' gray';
const sidebar_monitor_color_dark = 'green';
const monitor_log_background_color_dark = '#282c34';
const monitor_log_color_dark = '#9caaba';
const monitor_queue_background_color_dark = '#1d2026';
const monitor_queue_color_dark = '#9caaba';

function setLightTheme() {
    document.getElementById('theme-toggle-icon').classList.remove('fa-sun-o');
    document.getElementById('theme-toggle-icon').classList.add('fa-moon-o');
    document.documentElement.style.setProperty('--header-background-color', header_background_color_light);
    document.documentElement.style.setProperty('--header-color', header_color_light);
    document.documentElement.style.setProperty('--theme-toggle-background-color', theme_toggle_background_color_light);
    document.documentElement.style.setProperty('--theme-toggle-color', theme_toggle_color_light);
    document.documentElement.style.setProperty('--body-background-color', body_background_color_light);
    document.documentElement.style.setProperty('--body-color', body_color_light);
    document.documentElement.style.setProperty('--page-content-background-color', page_content_background_color_light);
    document.documentElement.style.setProperty('--page-content-color', page_content_color_light);
    document.documentElement.style.setProperty('--sidebar-menu-background-color', sidebar_menu_background_color_light);
    document.documentElement.style.setProperty('--sidebar-menu-a-color', sidebar_menu_a_color_light);
    document.documentElement.style.setProperty('--sidebar-menu-a-active-background-color', sidebar_menu_a_active_background_color_light);
    document.documentElement.style.setProperty('--sidebar-menu-a-active-color', sidebar_menu_a_active_color_light);
    document.documentElement.style.setProperty('--sidebar-menu-a-hover-background-color', sidebar_menu_a_hover_background_color_light);
    document.documentElement.style.setProperty('--sidebar-menu-a-hover-color', sidebar_menu_a_hover_color_light);
    document.documentElement.style.setProperty('--tab-content-background-color', tab_content_background_color_light);
    document.documentElement.style.setProperty('--tab-content-color', tab_content_color_light);
    document.documentElement.style.setProperty('--sidebar-monitor-background-color', sidebar_monitor_background_color_light);
    document.documentElement.style.setProperty('--sidebar-monitor-color', sidebar_monitor_color_light);
    document.documentElement.style.setProperty('--monitor-log-background-color', monitor_log_background_color_light);
    document.documentElement.style.setProperty('--monitor-log-color', monitor_log_color_light);
    document.documentElement.style.setProperty('--monitor-queue-background-color', monitor_queue_background_color_light);
    document.documentElement.style.setProperty('--monitor-queue-color', monitor_queue_color_light);
}

function setDarkTheme() {
    document.getElementById('theme-toggle-icon').classList.remove('fa-moon-o');
    document.getElementById('theme-toggle-icon').classList.add('fa-sun-o');
    document.documentElement.style.setProperty('--header-background-color', header_background_color_dark);
    document.documentElement.style.setProperty('--header-color', header_color_dark);
    document.documentElement.style.setProperty('--theme-toggle-background-color', theme_toggle_background_color_dark);
    document.documentElement.style.setProperty('--theme-toggle-color', theme_toggle_color_dark);
    document.documentElement.style.setProperty('--body-background-color', body_background_color_dark);
    document.documentElement.style.setProperty('--body-color', body_color_dark);
    document.documentElement.style.setProperty('--page-content-background-color', page_content_background_color_dark);
    document.documentElement.style.setProperty('--page-content-color', page_content_color_dark);
    document.documentElement.style.setProperty('--sidebar-menu-background-color', sidebar_menu_background_color_dark);
    document.documentElement.style.setProperty('--sidebar-menu-a-color', sidebar_menu_a_color_dark);
    document.documentElement.style.setProperty('--sidebar-menu-a-active-background-color', sidebar_menu_a_active_background_color_dark);
    document.documentElement.style.setProperty('--sidebar-menu-a-active-color', sidebar_menu_a_active_color_dark);
    document.documentElement.style.setProperty('--sidebar-menu-a-hover-background-color', sidebar_menu_a_hover_background_color_dark);
    document.documentElement.style.setProperty('--sidebar-menu-a-hover-color', sidebar_menu_a_hover_color_dark);
    document.documentElement.style.setProperty('--tab-content-background-color', tab_content_background_color_dark);
    document.documentElement.style.setProperty('--tab-content-color', tab_content_color_dark);
    document.documentElement.style.setProperty('--sidebar-monitor-background-color', sidebar_monitor_background_color_dark);
    document.documentElement.style.setProperty('--sidebar-monitor-color', sidebar_monitor_color_dark);
    document.documentElement.style.setProperty('--monitor-log-background-color', monitor_log_background_color_dark);
    document.documentElement.style.setProperty('--monitor-log-color', monitor_log_color_dark);
    document.documentElement.style.setProperty('--monitor-queue-background-color', monitor_queue_background_color_dark);
    document.documentElement.style.setProperty('--monitor-queue-color', monitor_queue_color_dark);
}

function toggleTheme() {
    if (document.getElementById('theme-toggle-icon').classList.contains('fa-moon-o')) {
        setDarkTheme();
    }
    else {
        setLightTheme();
    }
}
