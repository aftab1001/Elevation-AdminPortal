import CreateFoundationInput from './dto/createFoundationInput';
import CreateFoundationOutput from './dto/createFoundationOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllFoundationOutput } from './dto/getAllFoundationOutput';
import GetFoundationOutput from './dto/getFoundationOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import {PagedFoundationResultRequestDto} from './dto/PagedFoundationResultRequestDto';
import UpdateFoundationInput from './dto/updateFoundationInput';
import UpdateFoundationOutput from './dto/updateFoundationOutput';
import http from '../httpService';

class FoundationService {
  public async create(createFoundationInput: CreateFoundationInput): Promise<CreateFoundationOutput> {
    let result = await http.post('api/services/app/Foundation/Create', createFoundationInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Foundation/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetFoundationOutput> {
    let result = await http.get('api/services/app/Foundation/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedFoundationResultRequestDto): Promise<PagedResultDto<GetAllFoundationOutput>> {
    let result = await http.get('api/services/app/Foundation/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateFoundationInput: UpdateFoundationInput): Promise<UpdateFoundationOutput> {
    let result = await http.put('api/services/app/Foundation/Update', updateFoundationInput);
    return result.data.result;
  }
}

export default new FoundationService();
