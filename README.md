# Valant

This project was generated using [Nx](https://nx.dev).

[Nx Documentation](https://nx.dev/getting-started/nx-and-angular)

[Interactive Tutorial](https://nx.dev/angular-tutorial/01-create-application)

## How to play
Go to [how to play](./HowToPlay.md) to get more information about how to play it.

## Get started

Run `npm install` to install the UI project dependencies. Grab a cup of coffee or your beverage of choice.
You may also need to run `npm install start-server-and-test` and `npm install cross-env`

As you build new controller endpoints you can auto generate the api http client code for angular using `npm run generate-client:server-app`

## Development server

Run `npm run start` for a dev server. Navigate to http://localhost:4200/. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng g component my-component --project=demo` to generate a new component.

## Build

Run `ng build demo` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

- Run `ng test demo` to execute the unit tests via [Jest](https://jestjs.io).
- Run `nx affected:test` to execute the unit tests affected by a change.
- Run `npm run test:all` to run all unit tests in watch mode. They will re-run automatically as you make changes that affect the tests.

## Node version used
There were some library miss-matches and node version v18.13.0 was the one that correctly allowed the development of this app.

## Considerations

* The application loads the games in memory so every time the app gets restarted the games will be deleted.
* The 6 hrs timeframe was not enough to complete a lot of good practices or front-end unit tests or back-end unit tests, only integration tests were created in the backend.
* Some assumptions were made, due to the limitation in communication with the person who wrote the requirements.