import CreateResturantInput from './dto/createResturantInput';
import CreateResturantOutput from './dto/createResturantOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllResturantOutput } from './dto/getAllResturantOutput';
import GetResturantOutput from './dto/getResturantOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import {PagedResturantResultRequestDto} from './dto/PagedResturantResultRequestDto';
import UpdateResturantInput from './dto/updateResturantInput';
import UpdateResturantOutput from './dto/updateResturantOutput';
import http from '../httpService';

class ResturantService {
  public async create(createResturantInput: CreateResturantInput): Promise<CreateResturantOutput> {
    let result = await http.post('api/services/app/Resturant/Create', createResturantInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Resturant/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetResturantOutput> {
    let result = await http.get('api/services/app/Resturant/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedResturantResultRequestDto): Promise<PagedResultDto<GetAllResturantOutput>> {
    let result = await http.get('api/services/app/Resturant/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateResturantInput: UpdateResturantInput): Promise<UpdateResturantOutput> {
    let result = await http.put('api/services/app/Resturant/Update', updateResturantInput);
    return result.data.result;
  }
}

export default new ResturantService();
