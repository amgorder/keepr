import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaults() {
    try {
      const res = await api.get('api/vaults')
      console.log(res)
      AppState.vaults = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getVault(id) {
    try {
      const res = await api.get('api/vaults/' + id)
      console.log(res)
      AppState.activeVault = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async createVault(vault) {
    await api.post('api/vaults', vault)
    this.getVaults()
  }
}
export const vaultService = new VaultsService()
