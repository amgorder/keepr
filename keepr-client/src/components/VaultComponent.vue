<template>
  <div class="vaultComponent">
    <h1>Hello World</h1>
  </div>
</template>

<script>
export default {
  name: 'VaultComponent',
  props: {
    vaultProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
