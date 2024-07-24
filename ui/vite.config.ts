import { sentryVitePlugin } from "@sentry/vite-plugin";
import path from "path";
import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import tailwind from "tailwindcss";
import autoprefixer from "autoprefixer";
import { templateCompilerOptions } from '@tresjs/core'

export default defineConfig({
  css: {
    postcss: {
      plugins: [tailwind(), autoprefixer()],
    },
  },

  plugins: [vue({
    ...templateCompilerOptions
  }), sentryVitePlugin({
    org: "kristian-knudsen",
    project: "javascript-vue"
  })],

  server: {
    watch: {
      usePolling: true
    }
  },

  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },

  build: {
    sourcemap: true
  }
})