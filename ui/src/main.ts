import { createApp, markRaw } from 'vue';
import './master.css';
import App from './App.vue';
import { createPinia } from 'pinia';
import { router } from './router';
import Tres from '@tresjs/core';
// import * as Sentry from "@sentry/vue";

const app = createApp(App);
const pinia = createPinia();

pinia.use(({ store }) => {
    store.router = markRaw(router);
});

// Sentry.init({
//     app,
//     dsn: "https://33e46082fda7ad5680886ccd4b5afce0@o4507647540658176.ingest.de.sentry.io/4507647542165584",
//     integrations: [
//       Sentry.browserTracingIntegration(),
//       Sentry.replayIntegration(),
//     ],
//     // Performance Monitoring
//     tracesSampleRate: 1.0, //  Capture 100% of the transactions
//     // Set 'tracePropagationTargets' to control for which URLs distributed tracing should be enabled
//     tracePropagationTargets: ["localhost", /^https:\/\/yourserver\.io\/api/],
//     // Session Replay
//     replaysSessionSampleRate: 0.1, // This sets the sample rate at 10%. You may want to change it to 100% while in development and then sample at a lower rate in production.
//     replaysOnErrorSampleRate: 1.0, // If you're not already sampling the entire session, change the sample rate to 100% when sampling sessions where errors occur.
//   });


app
  .use(pinia)
  .use(router)
  .use(Tres)
  .mount('#app')
