<template>
  <div>
    <b-navbar>
      <template slot="brand">
        <b-navbar-item
          tag="nuxt-link"
          :to="{ path: '/' }"
        >
          <b-icon icon="chart-bar" />
          <span class="is-size-4">Planilha Financeira</span>
        </b-navbar-item>
      </template>
      <template slot="start">
        <b-navbar-item
          tag="nuxt-link"
          :to="{ path: '/' }"
        >
          Home
        </b-navbar-item>

        <b-navbar-item
          tag="nuxt-link"
          :to="{ path: '/config' }"
        >
          Configurações
        </b-navbar-item>
      </template>

      <template slot="end">
        <b-navbar-item tag="div">
          <div class="buttons">
            <a class="button is-primary">
              <strong>Sign up</strong>
            </a>
            <a class="button is-light">
              Log in
            </a>
          </div>
        </b-navbar-item>
      </template>
    </b-navbar>
    <section class="main-content columns">
      <div class="container column is-10">
        <nuxt />
      </div>
    </section>
  </div>
</template>

<script>
export default {

}
</script>

<style lang="scss">
@import "~assets/styles/main.scss";
</style>
