# An extract endpoint code, that belongs to a Sinatra(ruby) REST API. The endpoint provides
# ingestion stream data stats to callers. This endpoint is used to provide troubleshooting data to
# content delivery network support teams.

class WorkloadController < ApplicationController

	# Fetch all ingested stream worloads
	get '/' do
		begin
			offset = params[:offset].to_i > 0	? params[:offset].to_i 	: 1
			limit  = params[:limit].to_i > 0 	? params[:limit].to_i : 50


			# setup the workload filters
			workload_filters = DataCollectors::Service::RepositoryFilter.new(DataCollectors::Model::Workload.columns)
			workload_filters.add_filter_lambda('started_on', ->(date) {return Regexp.new(date)})
			built_filters = workload_filters.build(params) # use URL params to build filters

			workload_repository = DataCollectors::Repository::WorkloadRepository.new(DataCollectors::Model::Workload)

			workloads = workload_repository.get_workloads(built_filters,offset,limit)

			{ type: 'workloads', data: { matches: workloads.size, offset: offset, limit: limit, workloads: workloads } }.to_json

		rescue StandardError => e
			status 400
			{ type: 'workloads', error: e }.to_json			
		end
	end
end