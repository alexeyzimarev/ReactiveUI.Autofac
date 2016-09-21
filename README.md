# Autofac.ReactiveUI
Autofac adapter for ReactiveUI.

Includes both registration extentsions and dependency resolver adapter for Splat.

### Installation

Install from nuget.org:

```
Install-package ReactiveUI.Autofac
```

or using Paket:

* Add `nuget ReactiveUI.Autofac` to your `paket.dependencies` file
* Add `ReactiveUI.Autofac` to the required `paket.references` files
* Run `paket install`

### Usage

```c#
var builder = new ContainerBuilder();

// do your own registrations here

// call registration extension to register:
// - views
// - view models
// - screen
builder.RegisterForReactiveUI(assembly1, assembly2);

RxAppAutofacExtension.UseAutofacDependencyResolver(builder.Build());
```

### Details

Views are registered by scanning assemblies for all classes that implement `IViewFor<>` generic interface.

View models are scanned by name, your view model classes *must* have `ViewModel` as part of the class name.

Screen is registered by searching for an implementaiton of the `IScreen` interface. Hence you should only have one screen but we register all we can find.

Screen is registered as singleton, all other types are registered with defaults (instance per dependency).