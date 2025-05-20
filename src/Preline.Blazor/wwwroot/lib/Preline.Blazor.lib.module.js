import "./preline/preline.min.js";

function debouce(handler, timeout = 100) {
    let id;
    return (...args) => {
        clearTimeout(id);
        id = setTimeout(handler, timeout, args);
    }
}

const debouncedAutoInit = debouce(() => {
    if (typeof HSStaticMethods === 'object' && typeof HSStaticMethods.autoInit === 'function') {
        HSStaticMethods.autoInit();
    }
})

const observer = new MutationObserver(() => {
    debouncedAutoInit();
});

observer.observe(document.body, {
    childList: true,
    subtree: true,
})

if (typeof HSStaticMethods === 'object' && typeof HSStaticMethods.autoInit === 'function') {
    HSStaticMethods.autoInit();
}