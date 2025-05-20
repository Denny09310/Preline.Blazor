# Blazor.Preline

A Blazor component library that wraps [Preline UI](https://github.com/htmlstreamofficial/preline) components to provide a native and idiomatic experience for Blazor developers.

> ⚠️ This project is not affiliated with or endorsed by Preline or HTMLStream. It is an independent wrapper project built to enable Blazor developers to use Preline UI in a more seamless and Blazor-friendly way.

## 📦 What is Preline?

[Preline UI](https://github.com/htmlstreamofficial/preline) is a modern, open-source UI component library based on Tailwind CSS. It provides ready-to-use components like modals, dropdowns, alerts, tabs, and more.

## 🚀 Purpose of This Library

While Preline is built for traditional frontend stacks (HTML + Tailwind + JS), integrating it into a Blazor project requires manual setup and DOM manipulation. This library:

- Provides Razor components for Preline elements
- Wraps behavior in idiomatic C# and Blazor event bindings
- Abstracts JavaScript interop when necessary
- Simplifies usage with clean component APIs

## ✅ Features

- ✔️ Component wrappers for popular Preline UI elements
- ✔️ Seamless integration with Blazor Server and WebAssembly
- ✔️ Follows clean code practices for maintainability
- ✔️ Progressive enhancement: JS is used only where needed
- ✔️ Extensible and testable component model

## 📄 Example Usage

Taken from the [dropdown section](https://preline.co/docs/dropdown.html) the component can be rewritten in Blazor like the following:

```razor
<Dopdown>
  <DropdownToggle class="py-3 px-4 inline-flex items-center gap-x-2 text-sm font-medium rounded-lg border border-gray-200 bg-white text-gray-800 shadow-2xs hover:bg-gray-50 focus:outline-hidden focus:bg-gray-50 disabled:opacity-50 disabled:pointer-events-none dark:bg-neutral-800 dark:border-neutral-700 dark:text-white dark:hover:bg-neutral-700 dark:focus:bg-neutral-700">
    Actions
    <svg class="hs-dropdown-open:rotate-180 size-4" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="m6 9 6 6 6-6"/></svg>
  </DropdownToggle>

  <DropdownMenu class="transition-[opacity,margin] duration min-w-60 bg-white shadow-md rounded-lg mt-2 dark:bg-neutral-800 dark:border dark:border-neutral-700 dark:divide-neutral-700 after:h-4 after:absolute after:-bottom-4 after:start-0 after:w-full before:h-4 before:absolute before:-top-4 before:start-0 before:w-full">
    <div class="p-1 space-y-0.5">
      <a class="flex items-center gap-x-3.5 py-2 px-3 rounded-lg text-sm text-gray-800 hover:bg-gray-100 focus:outline-hidden focus:bg-gray-100 dark:text-neutral-400 dark:hover:bg-neutral-700 dark:hover:text-neutral-300 dark:focus:bg-neutral-700" href="#">
        Newsletter
      </a>
      <a class="flex items-center gap-x-3.5 py-2 px-3 rounded-lg text-sm text-gray-800 hover:bg-gray-100 focus:outline-hidden focus:bg-gray-100 dark:text-neutral-400 dark:hover:bg-neutral-700 dark:hover:text-neutral-300 dark:focus:bg-neutral-700" href="#">
        Purchases
      </a>
      <a class="flex items-center gap-x-3.5 py-2 px-3 rounded-lg text-sm text-gray-800 hover:bg-gray-100 focus:outline-hidden focus:bg-gray-100 dark:text-neutral-400 dark:hover:bg-neutral-700 dark:hover:text-neutral-300 dark:focus:bg-neutral-700" href="#">
        Downloads
      </a>
      <a class="flex items-center gap-x-3.5 py-2 px-3 rounded-lg text-sm text-gray-800 hover:bg-gray-100 focus:outline-hidden focus:bg-gray-100 dark:text-neutral-400 dark:hover:bg-neutral-700 dark:hover:text-neutral-300 dark:focus:bg-neutral-700" href="#">
        Team Account
      </a>
    </div>
  </DropdownMenu>
</Dopdown>
````

## 🔧 Installation

> Coming soon via NuGet

For now, clone the repo and add the project reference manually.

```bash
dotnet add reference ../Blazor.Preline/Blazor.Preline.csproj
```

Follow the [instructions](https://preline.co/docs/) to install the preline library.

## 🛠️ How It Works

This library uses a combination of:

* Razor component structure
* C# for logic and events
* JS Interop (via `IJSRuntime`) for Preline-specific behaviors

It does **not** reimplement Preline styles or JavaScript—this wrapper relies entirely on the official Preline assets.

## 🤝 Attribution

* This project wraps and depends on [Preline UI](https://github.com/htmlstreamofficial/preline), created and maintained by [@htmlstreamofficial](https://github.com/htmlstreamofficial).
* All credit for design, style, and JavaScript functionality goes to the original authors.
* This library aims to **respect the original license** and simply bridge the gap for Blazor developers.

## 📈 Roadmap

* [ ] Wrap all core components (buttons, modals, alerts, tabs)
* [ ] Add documentation site with live Blazor examples
* [ ] Support custom theming and Tailwind integration
* [ ] Publish to NuGet

## 💬 Contributing

Contributions, ideas, and bug reports are welcome!

If you want to wrap a new component or report an integration issue, feel free to open an issue or a pull request.

## 📄 License

This project is open-source under the MIT license. See `LICENSE` for details.

---

Made with ❤️ for the Blazor and Tailwind community.