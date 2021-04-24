<template>
  <div class="ProfilePage container-fluid text-light">
    <div class="row">
      <!-- <div class="col" v-if="state.loading"></div> -->
      <div class="col" v-if="!state.loading && state.profile.name">
        <h1>Welcome to {{ state.profile.name.includes('@') ? state.profile.name.split('@')[0] : state.profile.name }}'s Page </h1>
        <img :src="state.profile.picture" alt="">
        <h1>KEEPS COUNT: {{ state.keeps.length }}</h1>
        <h1>VAULTS COUNT: {{ state.vaults.length }}</h1>
      </div>
    </div>
    <div class="row">
      <h1 class="col-12">
        VAULTS
      </h1>
      <vault-component v-for="v in state.vaults" :key="v.id" :vault-prop="v" class="vault-component" />
    </div>
    <div class="row">
      <h1 class="col-12">
        KEEPS
      </h1>
      <keep-component class="keep-component d-flex" v-for="k in state.keeps" :key="k.id" :keep-prop="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      loading: true,
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)

    })
    onMounted(() => {
      profilesService.getProfileById(route.params.id)
      state.loading = false
      keepsService.getKeepsByProfileId(route.params.id)
    })
    return { state }
  }
}
</script>

<style scoped>

.keep-component {
  height: 10rem;
  width: 12rem;
  padding: 3px;
  margin: 3px;
  display: inline-block;
 }

.keep-component:nth-child(2n) {
  height: 20rem !important;
  width: 12rem !important;
 }

.keep-component:nth-child(3n) {
  height: 18rem !important;
  width: 12rem !important;
 }
.keep-component:nth-child(4n) {
  height: 15rem !important;
  width: 12rem !important;
 }
</style>
