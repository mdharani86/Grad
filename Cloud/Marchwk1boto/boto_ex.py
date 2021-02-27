import boto3
from pprint import pprint

s3 = boto3.resource('s3')

print('S3 buckets')
for bucket in s3.buckets.all():
    pprint(bucket)
print()
region = input('Enter AWS region: ')
print(f'EC2 instance in {region}')

ec2 = boto3.resource('ec2',region_name=region)
for inst in ec2.instances.all():
    print(inst)
print()

print(f'EC2 instance (id, state)')
for inst in ec2.instances.all():
    print(inst.id, inst.state)