const iconScales = ['60px', '80px', '100px', '120px','140px','160px'];

function storageUpscale() {
    var index = getScaleIndex();

    if (index >= 0 && index + 1 < iconScales.length) {
        index = index + 1;
    }
    else {
        return;
    }

    setScale(iconScales[index]);
}

function storageDownscale() {
    var index = getScaleIndex();

    if (index > 0) {
        index = index - 1;
    }
    else {
        return;
    }

    setScale(iconScales[index]);
}

function getScaleIndex() {
    var style = window.getComputedStyle(document.body)
    var currentScale = style.getPropertyValue('--storage-item-icon-size');
    return iconScales.findIndex((x) => x === currentScale);
}

function setScale(s) {
    document.documentElement.style.setProperty('--storage-item-icon-size', s);
}