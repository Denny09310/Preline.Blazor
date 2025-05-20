export function init(element, instance, options) {
    const overlay = new HSOverlay(element, options);
    overlay.on('open', () => instance.invokeMethodAsync("NotifyVisibilityChanged", true));
    overlay.on('close', () => instance.invokeMethodAsync("NotifyVisibilityChanged", false));
    return overlay;
}