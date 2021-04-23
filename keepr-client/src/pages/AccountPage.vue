<template>
  <div class="about container-fluid">
    <div class="row mb-5">
      <div class="col-6" v-if="!state.loading && state.account.name">
        <h1>Welcome {{ state.account.name.includes('@') ? state.account.name.split('@')[0] : state.account.name }} to your Account Page!</h1>
        <img class="pic" :src="state.account.picture" alt="" />
      </div>
    </div>
    <div class="row">
      <!-- Button trigger modal -->
      <div>
        <button type="button" class="btn btn-primary border-wrap" data-toggle="modal" data-target="#keepModalCenter">
          <span></span><span></span><span></span><span></span>
          + KEEP
        </button>
      </div>

      <!-- Modal -->
      <div class="modal fade"
           id="keepModalCenter"
           tabindex="-1"
           role="dialog"
           aria-labelledby="keepModalCenterTitle"
           aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="keepModalLongTitle">
                New Keep:
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form @submit.prevent="createKeep">
                <input class="m-3" type="text" v-model="state.newKeep.name" placeholder="Enter a name">
                <input class="m-3" type="text" v-model="state.newKeep.img" placeholder="Enter a img">
                <input class="m-3" type="text" v-model="state.newKeep.description" placeholder="Enter a description">
                <button type="submit" class="btn btn-primary">
                  Create Keep
                </button>
              </form>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
            </div>
          </div>
        </div>
      </div>

      <!-- Button trigger modal -->
      <div>
        <button type="button" class="btn btn-primary border-wrap" data-toggle="modal" data-target="#vaultModalCenter">
          <span></span><span></span><span></span><span></span>
          + VAULT
        </button>
      </div>

      <!-- Modal -->
      <div class="modal fade"
           id="vaultModalCenter"
           tabindex="-1"
           role="dialog"
           aria-labelledby="vaultModalCenterTitle"
           aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="vaultModalLongTitle">
                New Vault:
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form @submit.prevent="createVault">
                <input class="m-3" type="text" v-model="state.newVault.name" placeholder="Enter a name">
                <input class="m-3" type="text" v-model="state.newVault.img" placeholder="Enter a image">
                <label class="btn btn-primary">
                  <input type="checkbox" autocomplete="off"> Public
                </label>
              </form>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
              <button type="submit" class="btn btn-primary">
                Create Vault
              </button>
            </div>
          </div>
        </div>
      </div>

      <div class="col p-3">
      </div>
    </div>
    <br>
    <div class="row">
      <h1>VAULTS</h1>
      <vault-component v-for="v in state.vaults" :key="v.id" :vault-prop="v" class="vault-component" />
    </div>
    <br>
    <div>
      <div class="grid" data-masonry="{ itemSelector: &quot;.grid-item&quot;, &quot;columnWidth&quot;: 200 }">
        <h1>KEEPS</h1>
        <keep-component v-for="k in state.keeps" :key="k.id" :keep-prop="k" class="keep-component" />
      </div>
    </div>
  </div>
</template>
<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'Account',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      newKeep: {},
      newVault: {}
    })
    onMounted(() => keepsService.getKeepsByAccountId())
    onMounted(() => vaultsService.getVaultsByAccountId())

    return {
      state,
      createKeep() {
        keepsService.createKeep(state.newKeep)
        state.newKeep = {}
      },
      createVault() {
        vaultsService.createVault(state.newVault)
        state.newVault = {}
      }

    }
  }
}

</script>

<style scoped>
.vault {
  height: 100px;
  width: 100px;
}

img {
  max-width: 100px;
}

.pic{
  display: inline-block;
  padding: 4px;

  background: linear-gradient(130deg, hsl(150, 99%, 48%), hsl(275, 99%, 48%));
  object-fit: cover;
  margin: auto;
  border-radius: 50%;
  width: 100px;
  height:100px;
  box-shadow: 6px,6px,12px,16px black;
}

.border-wrap{
  text-decoration: none;
  transition: 0.2s;
  overflow: hidden;
}

.border-wrap:hover{
  color: #aa50e2;
  background: rgba(0, 255, 255, 0.63);
  box-shadow: 0 0 10px aqua, 0 0 40px rgba(121, 252, 252, 0.76), 0 0 80px aqua;
  transition-delay: 1s;

}
.border-wrap span{
  position: absolute;
  display: block;
}
.border-wrap span:nth-child(1){
  top: 0;
  left: -100%;
  width: 100%;
  height: 2px;
  background: linear-gradient(90deg,transparent,#aa50e2);
}
.border-wrap:hover span:nth-child(1){
  left: 100%;
  transition: 1s;
}
.border-wrap span:nth-child(3){
  bottom: 0;
  right: -100%;
  width: 100%;
  height: 2px;
  background: linear-gradient(270deg,transparent,#aa50e2);
}
.border-wrap:hover span:nth-child(3){
  right: 100%;
  transition: 1s;
  transition-delay: 0.5s;

}
.border-wrap span:nth-child(2){
  top: -100%;
  right: 0;
  width: 2px;
  height: 100%;
  background: linear-gradient(180deg,transparent,#aa50e2);
}
.border-wrap:hover span:nth-child(2){
  top: 100%;
  transition: 1s;
  transition-delay: 0.25s;
}
.border-wrap span:nth-child(4){
  bottom: -100%;
  left: 0;
  width: 2px;
  height: 100%;
  background: linear-gradient(360deg,transparent,#aa50e2);
}
.border-wrap:hover span:nth-child(4){
  bottom: 100%;
  transition: 1s;
  transition-delay: 0.75s;
}

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
