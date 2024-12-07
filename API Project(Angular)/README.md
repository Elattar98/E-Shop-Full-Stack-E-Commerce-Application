ithub.com/reactivex/rxjs/compare/7.4.0...7.5.0) (2021-12-27)

### Bug Fixes

- **takeWhile:** Now returns proper types when passed a `Boolean` constructor. ([#6633](https://github.com/reactivex/rxjs/issues/6633)) ([081ca2b](https://github.com/reactivex/rxjs/commit/081ca2ba7290aa3084c1477a6d4bcc573bf478f6))
- **forEach:** properly unsubs after error in next handler ([#6677](https://github.com/reactivex/rxjs/issues/6677)) ([b9ab67d](https://github.com/reactivex/rxjs/commit/b9ab67d21ca9d227fcd1123bf80ab87ca9296af9)), closes [#6676](https://github.com/reactivex/rxjs/issues/6676)
- **WebSocketSubject:** handle slow WebSocket close ([#6708](https://github.com/reactivex/rxjs/issues/6708)) ([8cb201c](https://github.com/reactivex/rxjs/commit/8cb201cd42dd751b4185b94fe2d36c6bfda02fe2)), closes [#4650](https://github.com/reactivex/rxjs/issues/4650) [#3935](https://github.com/reactivex/rxjs/issues/3935)
- RxJS now supports tslib 2.x, rather than just 2.1.x ([#6692](https://github.com/reactivex/rxjs/issues/6692)) ([0b2495f](https://github.com/reactivex/rxjs/commit/0b24