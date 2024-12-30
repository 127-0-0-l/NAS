window.onload = function () {
    const prefersDarkScheme = window.matchMedia("(prefers-color-scheme: dark)").matches;
    if (prefersDarkScheme) {
        setDarkTheme();
    }
    else {
        setLightTheme();
    }
}

//#region sidebar menu
function fetchAction(actionLink) {
    fetch(actionLink)
        .then(response => {
            if (!response.ok) {
                throw new Error('response error: ' + response.status);
            }
            return response.text();
        })
        .then(data => {
            document.getElementById('tab-content').innerHTML = data;
        })
        .catch(error => {
            console.error(error);
            return;
        });
    return true;
}

function deactivateMenuButton() {
    var activeBts = document.getElementsByClassName('menu-active');
    for (i = 0; i < activeBts.length; i++) {
        activeBts[i].classList.remove('menu-active');
    }
}

document.getElementById('menu-bt-index').addEventListener('click', function () {
    if (fetchAction('/Home/Home')) {
        deactivateMenuButton();
        this.classList.add('menu-active');
    }
});

document.getElementById('menu-bt-about').addEventListener('click', function () {
    fetchAction('/Home/About');
    deactivateMenuButton();
    this.classList.add('menu-active');
});

document.getElementById('menu-bt-contact').addEventListener('click', function () {
    fetchAction('/Home/Contact');
    deactivateMenuButton();
    this.classList.add('menu-active');
});

//#endregion

//#region sidebar monitor

//#endregion
