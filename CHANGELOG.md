## [1.2.0] - 20/03/2025

## Added a Custom Editor Window that Creates States, Events and Listeners for you

- Added a custom editor window that creates states, events and listeners for you, Only BaseState at the moment.

## [1.1.0] - 20/03/2025

### Refactoring and Improvements

- Refactored `ApplicationManager` to depend on `IState` instead of `BaseState` as suggested
  by [BackFromExile](https://www.reddit.com/r/Unity3D/comments/1jfdxiu/comment/mire8ly/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button)
  in Reddit.

## [1.0.0] - 18/03/2025

### Release

- Added Unit Tests
- Added basic states
- Added `GetCurrentState` method to `ApplicationManager`

## [0.0.3] - 15/03/2025

### Bug Fixes and Improvements

- Fixed a bug where Application Manager state machine was in start
- Moved change state function to EventListeners
- Added debug option to states
- Added state name to `BaseState` class
- Moved `EventListener` property to `BaseState` class

## [0.0.2] - 14/03/2025

### Updated Submenu to create states, events and listeners

- Added submenu to create states, events and listeners all from the same parent

## [0.0.1] - 14/03/2025

### Initial Release

- Added Improved Game Manager
- Can create states using scriptable objects
- Can change states using scriptable objects events
