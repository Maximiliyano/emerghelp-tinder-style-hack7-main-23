<template>
  <v-container
    fluid
    class="d-flex align-center justify-center"
    style="height: 90vh"
  >
    <v-card class="elevation-0" height="75vh">
      <vue-tinder
        ref="showroom"
        key-name="id"
        :queue.sync="requests"
        @submit="onSubmit"
      >
        <template slot-scope="{ data }">
          <div
            class="pic"
            :style="{
              'background-image': `url(${data.image})`,
            }"
          >
            <template v-if="!data.status">
              <v-layout justify-center column fill-height>
                <v-flex xs12>
                  <div class="container fluid fill-height pt-0">
                    <v-layout justify-center align-center>
                      <v-flex text-center>
                        <p class="headline font-weight-bold">
                          Ви переглянули всі заявки
                        </p>
                      </v-flex>
                    </v-layout>
                  </div>
                </v-flex>
              </v-layout>
            </template>
            <template v-else>
                  <v-card class="w100" :key="data.img" tile>
                    <v-card tile>
                      <v-img
                        v-if="!data.flipped"
                        class="rand white--text align-end"
                        height="75vh"
                        src="@/assets/showroom/1.png"
                        gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                      >
                        <v-card-title class="pb-2">Broken leg</v-card-title>

                        <v-card-text>
                          <v-chip
                            class="mb-4 mr-1"
                            v-for="i in ['Медикаменти', 'Їжа']"
                            :key="i"
                            >{{ i }}</v-chip
                          >

                          <v-row
                            justify="space-between"
                            align="center"
                            class="my-4 mx-0"
                            ><div class="text-subtitle-1">
                              Lviv, 20 km from you
                            </div>
                            <v-btn
                              color="white"
                              icon
                              dark
                              @click="data.flipped = !data.flipped"
                              ><v-icon dark> mdi-information </v-icon></v-btn
                            ></v-row
                          >
                        </v-card-text>
                      </v-img>
                      <div v-else class="h75">
                        <v-row
                          justify="space-between"
                          align="center"
                          class="ma-0"
                        >
                          <v-card-title class="pb-2">Broken leg</v-card-title>
                          <v-btn
                            color="black"
                            icon
                            dark
                            @click="data.flipped = !data.flipped"
                            ><v-icon> mdi-rotate-360 </v-icon></v-btn
                          >
                        </v-row>

                        <v-card-text>
                          <v-chip
                            class="mb-4 mr-1"
                            v-for="i in ['Медикаменти', 'Їжа']"
                            :key="i"
                            >{{ i }}</v-chip
                          >

                          <v-row
                            justify="space-between"
                            align="center"
                            class="ma-0"
                            ><div class="text-subtitle-1">
                              Lviv, 20 km from you
                            </div>
                           </v-row
                          >
                          <div class="black--text font-weight-bold ">Dmytro Romanenko</div>
                          <a href="tel:+380 66 343 22 34" class="text-subtitle-2 grey--text text-decoration-none">
                            +380 66 343 22 34
                          </a>
                        </v-card-text>
                        <v-card-text v-if="true" class="d-flex my-0 py-0 justify-start">
                          <a href="http://t.me/romnnko">
                            <v-btn
                              color="blue"
                              icon
                              dark
                              ><v-icon class="rotate45 mb-1">mdi-send</v-icon></v-btn>
                          </a>
                          <a>
                            <v-btn
                              color="purple"
                              icon
                              dark
                              ><v-icon>mdi-instagram</v-icon></v-btn>
                          </a>
                          <a>
                            <v-btn
                              color="blue"
                              icon
                              dark
                              ><v-icon>mdi-facebook</v-icon></v-btn>
                          </a>
                          <a href="http://t.me/romnnko">
                            <v-btn
                              color="blue"
                              icon
                              dark
                              ><v-icon>mdi-twitter</v-icon></v-btn>
                          </a>
                          <a href="http://t.me/romnnko">
                            <v-btn
                              color="grey"
                              icon
                              dark
                              ><v-icon>mdi-web</v-icon></v-btn>
                          </a>
                        </v-card-text>
                        <v-card-text v-else class="d-flex my-0 py-0 justify-start font-weight-bold">
                          Користувач не додав корисних посилань
                        </v-card-text>
                        <v-card-text class="text-caption">
                          19.05.2023 17:55
                        </v-card-text>
                        <v-card-text class="desc py-0 my-4">
                          <div class="black--text">
                            I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me I have broke my leg, and I need somebody to help me
                          </div>
                        </v-card-text>
                      </div>
                    </v-card>
                  </v-card>
            </template>
          </div>
        </template>

        <img class="like-pointer" slot="like" :src="yesTxt" />
        <img class="nope-pointer" slot="nope" :src="noTxt" />
        <img class="super-pointer" slot="super" :src="maybeTxt" />
        <img class="rewind-pointer" slot="rewind" :src="retryTxt" />
      </vue-tinder>

      <v-card-text
        style="color: black"
        v-if="title == 'bottom'"
        class="text-xs-center title mt-4"
      >
        <strong>Питання?</strong>
      </v-card-text>
      <v-slide-y-transition class="instruments">
        <div class="btns mx-5">
          <v-btn color="grey" fab dark @click="decide('rewind')"
            ><v-icon dark> mdi-backup-restore </v-icon></v-btn
          >
          <v-btn color="red" fab dark @click="decide('nope')"
            ><v-icon dark> mdi-close </v-icon></v-btn
          >
          <v-btn color="orange lighten-2" fab dark @click="decide('super')"
            ><v-icon dark> mdi-alert </v-icon></v-btn
          >
          <v-btn color="green" fab dark @click="decide('like')"
            ><v-icon dark> mdi-heart </v-icon></v-btn
          >
        </div>
      </v-slide-y-transition>
    </v-card>
  </v-container>
</template>

<script>
import source from '@/assets/showroom.json'

import VueTinder from 'vue-tinder'

import yesTxt from '@/assets/showroom/yes-txt.png'
import noTxt from '@/assets/showroom/no-txt.png'
import maybeTxt from '@/assets/showroom/maybe-txt.png'
import retryTxt from '@/assets/showroom/retry-txt.png'
import { mapGetters, mapMutations } from 'vuex'
// import { v4 as uuidv4 } from 'uuid'
import { updateUser, getRequests } from '@/firebaseDb'

export default {
  name: 'DepositsPage',
  data () {
    return {
      yesTxt: yesTxt,
      noTxt: noTxt,
      maybeTxt: maybeTxt,
      retryTxt: retryTxt,
      products: [],
      offset: 0,
      history: [],
      buttons: 'solid',
      background: false,
      title: 'top',
      productOut: true,
      requests: []
    }
  },
  async created () {
    await this.getUserData(this.$auth.user)
    this.requests = await getRequests()
    console.log(this.requests)
  },
  components: {
    VueTinder
  },
  methods: {
    ...mapMutations([
      'setFilteredOperations',
      'setOperations',
      'setLoading',
      'showSnackbar',
      'setSnackbar',
      'setUser'
    ]),
    async getUserData (user) {
      if (!this.loading) {
        try {
          await this.$store.dispatch('getUserInfo', user)
        } catch (e) {
          console.log(e)
          this.showSnackbar({
            message: 'Error occurred while fetching resources, refresh the page or try again later',
            color: 'error'
          })
        } finally {
          this.setLoading(false)
        }
      }
    },
    getProducts: function (count = 5) {
      this.products = []
      try {
        const list = []
        const newSource = source.filter((element) => Boolean(element.active))

        for (let i = 0; i < newSource.length; i++) {
          const obj = {
            ...newSource[this.offset],
            id: this.offset,
            image: `fotor1${i + 1}.jpg`,
            isProduct: true,
            flipped: false
          }
          list.push(obj)
          this.offset++
        }

        list.push({ id: count + 1, isProduct: false })
        this.products = this.products.concat(list)
      } catch (err) {
        console.log(err)
      }
    },
    decide: function (choice) {
      const a = navigator.geolocation.getCurrentPosition((b) => console.log(b))
      console.log(a)
      if (choice === 'rewind') {
        const length = this.history.length
        const el = this.history.pop()
        console.log(el)
        if (length) {
          this.$refs.showroom.rewind([el])
        }
      } else {
        console.log(choice)
        this.$refs.showroom.decide(choice)
      }
    },
    async onSubmit (data) {
      console.log(this.user)
      console.log('22')
      if (data.type === 'like') {
        console.log(data)
        await updateUser({ ...this.user, responses: this.user.responses ? [...this.user.responses, data.item] : [data.item] })
      }
      this.history.push(data.item)
      this.productOut = this.products.length > 1

      if (this.products.length === 0) this.goToCatalog()
    },
    goToCatalog: function () {
      this.$router.go(this.$router.currentRoute)
    }
  },
  computed: {
    ...mapGetters(['loading', 'filteredOperations', 'filterParams', 'user', 'operations'])
  }
}
</script>

<style scoped>
/* width */
::-webkit-scrollbar {
  width: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  background: #f1f1f1;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: #888;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #555;
}
.desc{
  max-height: 20vh;
  overflow-x: hidden; /* Hide horizontal scrollbar */
  overflow-y: scroll;
}
.rotate45 {
  transform: rotate(-45deg);
}
.h75 {
  height: 75vh
}
.w100 {
  width: 100%;
  position: relative;
  cursor: pointer;
  height: 75vh;
  z-index: 2;
  -webkit-box-shadow: -11px 49px 42px -26px rgba(168, 168, 168, 1);
  -moz-box-shadow: -11px 49px 42px -26px rgba(168, 168, 168, 1);
  box-shadow: -11px 49px 42px -26px rgba(168, 168, 168, 1);
  will-change: transform;
}
.flip-enter-active {
  transition: all 1s ease;
}

.flip-leave-active {
  display: none;
}

.flip-enter,
.flip-leave {
  transform: rotateY(180deg);
  opacity: 0;
}
.vue-tinder {
  position: absolute;
  margin: auto;
  z-index: 1;
  left: 0;
  right: 0;
  top: 5px;
  width: 100%;
  height: 100%;
  min-width: 350px;
  max-width: 350px;
}

.nope-pointer,
.like-pointer {
  position: absolute;
  z-index: 6;
  top: 30px;
  width: 96px;
  height: 96px;
  transition: all 1s ease;
}

.nope-pointer {
  right: 10px;
}

.like-pointer {
  left: 10px;
}

.super-pointer {
  transition: all 1s ease;
  position: absolute;
  z-index: 6;
  bottom: 0px;
  left: 80px;
  right: 0;
  margin: auto;
  width: 112px;
  height: 100px;
}

.rewind-pointer {
  position: absolute;
  z-index: 1;
  top: 30px;
  right: 10px;
  width: 96px;
  height: 96px;
}

.btns {
  position: relative;
  left: 0;
  bottom: 70px;
  z-index: 3;
  margin: auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.pic {
  width: 100%;
  height: 100%;
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
}
.bg-card {
  color: #fff;
  background: -webkit-linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
  background: -o-linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
  background: -moz-linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
  background: linear-gradient(150deg, #d9a94c 66%, #eae2c0 66%);
}

.item-name {
  position: relative;
  display: flex;
  flex-direction: column;
}

.rand {
  padding-bottom: 5em;
  width: 100%;
}
</style>
