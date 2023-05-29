<template>
  <v-app>
    <v-app-bar app clipped-left color="primary" dark>
      <v-app-bar-nav-icon
        v-if="$auth.isAuthenticated"
        @click="drawer = !drawer"
      />
      <v-img
        alt="ricecode help"
        class="shrink mr-2 mb-2"
        contain
        background="none"
        src=".././public/Swipe2Help.png"
        transition="scale-transition"
        width="60"
      />
      <h1 class="ml-100 mt-0">Swipe2Help</h1>
      <v-spacer />
    </v-app-bar>

    <v-navigation-drawer
      v-if="$auth.isAuthenticated"
      v-model="drawer"
      app
      clipped
      color="grey lighten-4"
      min-width="200"
    >
      <v-list dense nav>
        <v-list-item>
          <v-list>
            <v-list-item>
              <v-avatar class="mr-auto">
                <img :src="$auth.user.picture" alt="User Picture" />
              </v-avatar>
            </v-list-item>
            <v-list-item>
              <v-list-item-content class="pt-0">
                <v-list-item-title>
                  {{ $auth.user.name }}
                </v-list-item-title>
                <v-list-item-subtitle>{{
                  $auth.user.email
                }}</v-list-item-subtitle>
              </v-list-item-content>
            </v-list-item>
            <v-list-item v-if="!editBalance">
              <div class="text-right text-h6">{{ user.city }}</div>
              <v-btn icon @click="editBalance = !editBalance"
                ><v-icon color="primary">mdi-pencil</v-icon></v-btn
              >
            </v-list-item>
            <v-list-item v-if="editBalance">
              <div class="text-right text-h6"></div>
              <v-select
                regular
                append-icon="mdi-location"
                class="mb-3 mx-2 inputPrice"
                hide-details
                :items="['Луцьк', 'Луганськ', 'Маріуполь', 'Сімферополь', 'Херсон', 'Дніпро', 'Кременчук', 'Суми', 'Черкаси', 'Кіровоград', 'Миколаїв', 'Чернігів', 'Київ', 'Біла Церква', 'Умань', 'Чернівці', 'Ужгород', 'Вінниця', 'Житомир', 'Івано-Франківськ', 'Тернопіль', 'Львів'].sort((a, b) => a.localeCompare(b))"
                :value="user.city"
                v-model="city"
              ></v-select>
              <v-btn icon @click="changeCity();"
                ><v-icon color="green">mdi-check</v-icon></v-btn
              >
            </v-list-item>
          </v-list>
        </v-list-item>
        <v-list-item to="/deposits">
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Головна</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/operations">
          <v-list-item-action>
            <v-icon>mdi-email</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Запити</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/credits">
          <v-list-item-action>
            <v-icon>mdi-handshake</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Відгуки</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <template v-slot:append>
        <v-list dense>
          <v-list-item link @click="$auth.logout">
            <v-list-item-action>
              <v-icon>mdi-logout</v-icon>
            </v-list-item-action>
            <v-list-item-content>
              <v-list-item-title class="grey--text">
                Вийти
              </v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </template>
    </v-navigation-drawer>
    <v-main>
      <router-view />
    </v-main>
    <v-snackbar
      v-if="snackbarOriginPage === this.$router.currentRoute.path"
      :color="snackbarColor"
      v-model="snackbar"
    >
      {{ snackbarText }}
    </v-snackbar>
  </v-app>
</template>

<script>
import { mapState, mapGetters, mapMutations } from 'vuex'
import { updateUser } from '@/firebaseDb'
export default {
  name: 'App',

  components: {},
  data: () => ({
    editBalance: false,
    drawer: true,
    city: '',
    cities: {
      Львів: { x: 49.84234199810894, y: 24.037073747248037 },

      Луцьк: { x: 50.83716687670612, y: 25.425569407528013 },

      Тернопіль: { x: 49.556928085033846, y: 25.591749492481643 },

      Рівне: { x: 50.62633832511211, y: 26.25451486652829 },

      'Івано-Франківськ': { x: 48.92349326090518, y: 24.713523295375133 },

      Житомир: { x: 50.252783457652775, y: 28.689771570773534 },

      Вінниця: { x: 49.233299271673985, y: 28.443405506369118 },

      Ужгород: { x: 48.629689605885716, y: 22.280956361630032 },

      Чернівці: { x: 48.290682632393604, y: 25.93292601264505 },

      Умань: { x: 48.75040139443293, y: 30.219229861178626 },

      'Біла Церква': { x: 49.79652780396732, y: 30.117081613102577 },

      Київ: { x: 50.43204478887195, y: 30.543706285458796 },

      Чернігів: { x: 51.490469117792074, y: 31.298544128065398 },

      Миколаїв: { x: 46.97842425867205, y: 31.99542734364915 },

      Кіровоград: { x: 48.51092240984726, y: 32.26588975060307 },

      Черкаси: { x: 49.44622522161305, y: 32.059615344320164 },

      Суми: { x: 50.91222278564517, y: 34.80170922282769 },

      Кременчук: { x: 49.063356636603025, y: 33.4047288616714 },

      Дніпро: { x: 48.4667921056606, y: 35.03049428501556 },

      Херсон: { x: 46.64052555523459, y: 32.6156993036786 },

      Сімферополь: { x: 44.95521700065096, y: 34.09089328654027 },

      Маріуполь: { x: 47.09978938682072, y: 37.55515676813745 },

      Сєвєродонецьк: { x: 48.953545383460806, y: 38.490954351938505 },

      Луганськ: { x: 48.645906769301924, y: 39.49858079720463 }
    }
  }),
  methods: {
    ...mapMutations(['setUser']),
    async changeCity () {
      this.editBalance = !this.editBalance
      await updateUser({ ...this.user, city: this.city })
      this.setUser({ ...this.user, city: this.city })
    },
    displayLocation () {
      navigator.geolocation.getCurrentPosition((coord) => {
        console.log(coord)
        const request = new XMLHttpRequest()

        const method = 'GET'
        const url =
          'http://maps.googleapis.com/maps/api/geocode/json?latlng=' +
          coord.latitude +
          ',' +
          coord.longitude +
          '&sensor=true'
        const async = true

        request.open(method, url, async)
        request.onreadystatechange = function () {
          if (request.readyState === 4 && request.status === 200) {
            const data = JSON.parse(request.responseText)
            const address = data.results[0]
            document.write(address.formatted_address)
          }
        }
        request.send()
      })
    }
  },
  computed: {
    ...mapState(['snackbarColor', 'snackbarText', 'snackbarOriginPage']),
    ...mapGetters(['user']),
    snackbar: {
      get () {
        return this.$store.state.snackbar
      },
      set (value) {
        this.setSnackbar(value)
      }
    }
  },
  watch: {
    user: function (userValue) {
      this.city = userValue.city
    }
  }
}
</script>
<style lang="css" scoped>
.inputPrice >>> input[type="number"] {
  -moz-appearance: textfield;
}
.inputPrice >>> input::-webkit-outer-spin-button,
.inputPrice >>> input::-webkit-inner-spin-button {
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
}
</style>
