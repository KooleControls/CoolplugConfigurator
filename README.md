# Coolmaster Configurator

Coolmaster Configurator is a small Windows utility for automatically configuring CoolPlug devices.

## What it does

When a CoolPlug is connected via USB (COM port), the application:

* Detects the device automatically
* Reads the current line (L2) address
* Compares it with the configured target value
* Updates the address if it does not match

This removes the need for manual configuration and ensures devices are consistently set up.

## Use case

Designed for environments where multiple CoolPlug devices need to be configured quickly and reliably, such as:

* Production or assembly workflows
* Field installations
* Testing setups

Simply connect the device and let the tool handle the configuration.
