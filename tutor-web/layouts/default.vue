<template>
  <v-app>
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-toolbar-title>
        <v-btn nuxt to="/">
          <v-img src="/EWUlogo.png" width="150" contain></v-img>
          Tutoring
        </v-btn>
      </v-toolbar-title>
      <v-spacer />
      <v-text v-if="username != null">Welcome{{ username }}!</v-text>
      <v-btn icon @click.stop="rightDrawer = !rightDrawer">
        <v-icon>mdi-menu</v-icon>
      </v-btn>
    </v-app-bar>
    <v-main>
      <Nuxt />
    </v-main>
    <v-navigation-drawer v-model="rightDrawer" :right="right" temporary fixed>
      <v-list>
        <v-list-item>
          <v-list-item-title class="d-flex justify-center">
            <v-img src="/EWUlogo.png" width="150" contain></v-img>
          </v-list-item-title>
        </v-list-item>
        <v-list-item>
          <v-btn text block nuxt to="/"> Home <v-icon>mdi-home</v-icon></v-btn>
        </v-list-item>

        <v-list-item v-show="permLevel[0] != -1">
          <v-btn v-show="permLevel[0] == 0" text block nuxt to="/student">
            Ask A Question <v-icon>mdi-controller-classic</v-icon></v-btn
          >
        </v-list-item>
        <v-list-item v-show="permLevel[1] != -1">
          <v-btn v-show="permLevel[1] == 1" text block nuxt to="/tutor">
            Answer Questions <v-icon>mdi-controller-classic</v-icon></v-btn
          >
        </v-list-item>
        <v-list-item v-show="permLevel[2] != -1">
          <v-btn v-show="permLevel[2] == 2" text block nuxt to="/admin">
            View Statistics <v-icon>mdi-controller-classic</v-icon></v-btn
          >
        </v-list-item>

        <v-list-item v-if="isLoggedIn">
          <v-btn text block nuxt to="/user">
            Account <v-icon>mdi-account</v-icon>
          </v-btn>
        </v-list-item>

        <v-list-item v-if="isLoggedIn">
          <v-btn text block @click="deleteToken()">
            Log Out <v-icon>mdi-equalizer</v-icon>
          </v-btn>
        </v-list-item>

        <v-list-item v-if="!isLoggedIn">
          <v-btn text block>
            <login-dialog />
          </v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn text block>
            <SettingsDialog />
          </v-btn>
        </v-list-item>

        <v-list-item>
          <v-btn text block nuxt to="/about">
            About <v-icon>mdi-help-circle</v-icon></v-btn
          >
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
import { JWT } from '~/scripts/jwt'
import { AuthenticationCheck } from '~/scripts/methods'

export default {
  name: 'DefaultLayout',
  data() {
    return {
      clipped: false,
      right: true,
      rightDrawer: false,
      title: 'EWU Tutoring',
      isLoggedIn: false,
      jwt: JWT._getData,
      permLevel: [-1, -1, -1],
      username: null,
    }
  },
  async mounted() {
    if (JWT.loadToken(this.$axios) != null) {
      this.checkName()
      this.isLoggedIn = true
    }
    this.permLevel = await AuthenticationCheck(this.$axios)
  },
  methods: {
    deleteToken() {
      JWT.deleteToken()
      location.assign('/')
    },

    checkName() {
      this.$axios
        .post(
          '/Token/getName',
          {},
          {
            params: {
              username: JWT.getUserName(),
            },
          }
        )
        .then((result) => {
          this.username = ', ' + result.data
        })
        .catch(function (error) {})
    },
  },
}
</script>
