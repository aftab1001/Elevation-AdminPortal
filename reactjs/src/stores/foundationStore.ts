import { action, observable } from 'mobx';
import CreateFoundationInput from '../services/foundation/dto/createFoundationInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllFoundationOutput } from '../services/foundation/dto/getAllFoundationOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedFoundationResultRequestDto } from '../services/foundation/dto/PagedFoundationResultRequestDto';
import FoundationModel from '../models/Foundations/FoundationModel';
import UpdateFoundationInput from '../services/foundation/dto/updateFoundationInput';
import foundationService from '../services/foundation/foundationService';

class FoundationStore {
  @observable foundations!: PagedResultDto<GetAllFoundationOutput>;
  @observable foundationModel: FoundationModel = new FoundationModel();

  @action
  async create(createFoundationInput: CreateFoundationInput) {
    await foundationService.create(createFoundationInput);
  }

  @action
  async createFoundation() {
    this.foundationModel = {
      id: 0,
      image: '',     
      type: '', 
      upperText: '',
      headingText: '',
      description: '',
      
      
    };
  }

  @action
  async update(updateFoundationInput: UpdateFoundationInput) {
    let result = await foundationService.update(updateFoundationInput);

    this.foundations.items = this.foundations.items.map((x: GetAllFoundationOutput) => {
      if (x.id === updateFoundationInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await foundationService.delete(entityDto);
    this.foundations.items = this.foundations.items.filter((x: GetAllFoundationOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await foundationService.get(entityDto);
    this.foundationModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedFoundationResultRequestDto) {
    let result = await foundationService.getAll(pagedFilterAndSortedRequest);
    this.foundations = result;
  }
}

export default FoundationStore;
