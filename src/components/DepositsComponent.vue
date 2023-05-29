<template>
  <v-container fluid>
    <v-card
      class="elevation-0"
      height="80vh"
      :class="[
        background ? 'bg-card' : null,
        title == 'top' ? 'content' : null,
      ]"
    >
      <v-slide-y-transition>
        <v-card-text
          v-if="title == 'top' && productOut"
          class="text-xs-center title"
        >
          <strong>Ну і?</strong>
        </v-card-text>
      </v-slide-y-transition>

      <vue-tinder
        ref="showroom"
        key-name="id"
        :queue.sync="products"
        :offset-y="10"
        @submit="onSubmit"
      >
        <template slot-scope="{ data }">
          <div
            class="pic"
            :style="{
              'background-image': `url(${data.image})`,
            }"
          >
            <template v-if="!data.isProduct">
              <v-layout justify-center column fill-height>
                <v-flex xs12>
                  <div class="container fluid fill-height pt-0">
                    <v-layout justify-center align-center>
                      <v-flex md5 lg4 text-xs-center>
                        <p class="headline font-weight-bold primary--text">
                          Шо
                        </p>

                        <p class="title font-weight-bold">
                          Ти
                        </p>

                        <v-btn
                          block
                          large
                          dark
                          color="primary"
                          @click="goToCatalog"
                        >Так, я</v-btn
                        >
                      </v-flex>
                    </v-layout>
                  </div>
                </v-flex>
              </v-layout>
            </template>
            <template v-else>
              <div class="item-name">
                <img class="rand" :src="getImgUrl(data.image)"/>
                <span class="item-first">{{ data.name.split(" ")[0] }}</span>
                <span class="item-second">{{ data.name.split(" ")[1] }}</span>
                <span class="item-price">${{ data.price }}</span>
              </div>
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
      <v-slide-y-transition>
        <div class="btns">
          <v-btn color="yellow" outlined fab dark @click="decide('rewind')"><v-icon dark color="yellow">
            mdi-reload
        </v-icon></v-btn>
        <v-btn color="red" outlined fab dark @click="decide('nope')"><v-icon dark color="red">
            mdi-cancel
        </v-icon></v-btn>
        <v-btn color="blue" outlined fab dark @click="decide('super')"><v-icon dark color="blue">
            mdi-help
        </v-icon></v-btn>
        <v-btn color="green" outlined fab dark @click="decide('like')"><v-icon dark >
          mdi-heart
        </v-icon></v-btn>
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

export default {
  data () {
    return {
      yesTxt: yesTxt,
      noTxt: noTxt,
      maybeTxt: maybeTxt,
      retryTxt: retryTxt,
      URL: 'https://api.tissini.app/',
      products: [],
      offset: 0,
      history: [],
      buttons: 'solid',
      background: false,
      title: 'top',
      productOut: true,
      randomImg: ''
    }
  },
  created () {
    this.getProducts()
    this.randomImg = this.generateImg()
  },
  components: {
    VueTinder
  },
  methods: {
    generateImg () {
      return 'https://picsum.photos/300/200'
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
            isProduct: true
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
    getImgUrl (pic) {
      return require('@/assets/showroom/' + pic)
    },
    getTextImageUrl: function ({ name }) {
      return name.toLowerCase().replace(' ', '_') + '.jpg'
    },
    decide: function (choice) {
      if (choice === 'rewind') {
        if (this.history.length) {
          this.$refs.showroom.rewind([this.history.pop()])
        }
      } else {
        this.$refs.showroom.decide(choice)
      }
      this.randomImg = this.generateImg()
    },
    onSubmit ({ item }) {
      this.randomImg = this.generateImg()
      this.history.push(item)
      this.productOut = this.products.length > 1

      if (this.products.length === 0) this.goToCatalog()
    },
    goToCatalog: function () {
      this.$router.go(this.$router.currentRoute)
    }
  }
}
</script>

<style>
.vue-tinder {
  position: absolute;
  margin: auto;
  z-index: 1;
  left: 0;
  right: 0;
  top: 5px;
  width: 100%;
  height: 100%;
  min-width: 300px;
  max-width: 350px;
}

.nope-pointer,
.like-pointer {
  position: absolute;
  z-index: 1;
  top: 30px;
  width: 96px;
  height: 96px;
}

.nope-pointer {
  right: 10px;
}

.like-pointer {
  left: 10px;
}

.super-pointer {
  position: absolute;
  z-index: 1;
  bottom: 50px;
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
  position: absolute;
  left: 0;
  right: 0;
  z-index: 3;
  margin: auto;
  top: 530px;
  height: 65px;
  display: flex;
  align-items: center;
  justify-content: space-between;
  min-width: 200px;
  max-width: 300px;
}

.pic {
  width: 100%;
  height: 100%;
  background-size: cover;
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
  padding: 10px;
  display: flex;
  flex-direction: column;
  font-family: "walkway_black";
}
.item-name .item-first {
  font-size: 1.8em;
  font-weight: 500;
  padding: 0px;
  font-family: "Roboto";
  position: relative;
  color: #f06292;
  -webkit-text-stroke: 0.5px rgb(255, 98, 192);
}
.item-name .item-second {
  position: relative;
  font-size: 2.8em;
  padding: 0px;
  color: #f06292;
  font-family: "Roboto";
  -webkit-text-stroke: 0.5px rgb(255, 98, 192);
}
.item-name .item-price {
  position: relative;
  font-size: 18px;
  padding: 0px;
  font-family: "Roboto", sans-serif;
  color: #f06292;
  font-weight: bolder;
  -webkit-text-stroke: 0.5px rgb(255, 98, 192);
}

.rand {
  width: 300px;
  height: 200px;
}

</style>
