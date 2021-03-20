import CreateApartmentInput from './dto/createApartmentInput';
import CreateApartmentOutput from './dto/createApartmentOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllApartmentOutput } from './dto/getAllApartmentOutput';
import GetApartmentOutput from './dto/getApartmentOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import {PagedApartmentResultRequestDto} from './dto/PagedApartmentResultRequestDto';
import UpdateApartmentInput from './dto/updateApartmentInput';
import UpdateApartmentOutput from './dto/updateApartmentOutput';
import http from '../httpService';

class ApartmentService {
  public async create(createApartmentInput: CreateApartmentInput): Promise<CreateApartmentOutput> {
    let result = await http.post('api/services/app/Apartment/Create', createApartmentInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Apartment/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetApartmentOutput> {
    let result = await http.get('api/services/app/Apartment/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedApartmentResultRequestDto): Promise<PagedResultDto<GetAllApartmentOutput>> {
    let result = await http.get('api/services/app/Apartment/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateApartmentInput: UpdateApartmentInput): Promise<UpdateApartmentOutput> {
    let result = await http.put('api/services/app/Apartment/Update', updateApartmentInput);
    return result.data.result;
  }
}

export default new ApartmentService();
