import { RegisterMode } from '../common/register-mode';

export class RegisterModel
{
	public registerMode: RegisterMode;
	public countryCallingCode: string;
	public areaCode: string;
	public subscriberNumber: string;
	public emailAddress: string;
	public password: string;
	public firstName: string;
	public lastName: string;
}